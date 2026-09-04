using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Core.Metadata;

/// <summary>
/// Computes a <see cref="SegmentDefinition"/> from a model type alone, with no data files: positions and
/// names from the [Position] properties, coarse data types from the CLR property types, and required,
/// length and date/time rules by probing the type's Validate() method. Results are cached per type.
/// </summary>
public static class DerivedSegmentMetadata
{
    private static readonly ConcurrentDictionary<Type, SegmentDefinition> Cache = new ConcurrentDictionary<Type, SegmentDefinition>();

    [ThreadStatic]
    private static HashSet<Type> _inProgress;

    private static readonly Regex WordSplitRegex = new Regex("(?<=[a-z])(?=[A-Z])|(?<=[A-Za-z])(?=[0-9])", RegexOptions.Compiled);

    private static readonly Regex X12NamespaceRegex = new Regex(@"^Eddy\.x12\.Models\.v(\d{4})(\.Composites)?$", RegexOptions.Compiled);
    private static readonly Regex EdifactNamespaceRegex = new Regex(@"^Eddy\.Edifact\.Models\.(D\d{2}[A-Za-z])(\.Composites)?$", RegexOptions.Compiled);
    private static readonly Regex EdifactBetaNamespaceRegex = new Regex(@"^Eddy\.Edifact\.Models\.Beta(\.Composites)?$", RegexOptions.Compiled);

    private static readonly ErrorCodes[] ConditionalErrorCodes =
    {
        ErrorCodes.ARequiresB,
        ErrorCodes.IfOneIsFilledAllAreRequired,
        ErrorCodes.AtLeastOneIsRequired,
        ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired,
        ErrorCodes.OnlyOneOf,
        ErrorCodes.AorBRequired,
    };

    /// <summary>
    /// Describes <paramref name="segmentType"/>. <paramref name="standard"/> and <paramref name="version"/>
    /// are recorded on the result; pass what the caller knows (the catalog infers them from the
    /// namespace when null: "Eddy.x12.Models.v4010" gives X12/004010, "Eddy.Edifact.Models.D96A" gives EDIFACT/D96A).
    /// </summary>
    public static SegmentDefinition Describe(Type segmentType, string standard = null, string version = null)
    {
        if (segmentType == null)
            throw new ArgumentNullException(nameof(segmentType));

        var cached = Cache.GetOrAdd(segmentType, BuildDefinition);
        var result = cached.Clone();

        string inferredStandard, inferredVersion;
        InferStandardAndVersion(segmentType, out inferredStandard, out inferredVersion);
        result.Standard = standard ?? inferredStandard;
        result.Version = version ?? inferredVersion;
        return result;
    }

    /// <summary>Infers ("X12", "004010") or ("EDIFACT", "D96A") from a model type's namespace, or (null, null).</summary>
    public static void InferStandardAndVersion(Type modelType, out string standard, out string version)
    {
        standard = null;
        version = null;

        var ns = modelType?.Namespace;
        if (string.IsNullOrEmpty(ns))
            return;

        var match = X12NamespaceRegex.Match(ns);
        if (match.Success)
        {
            standard = "X12";
            version = "00" + match.Groups[1].Value;
            return;
        }

        match = EdifactNamespaceRegex.Match(ns);
        if (match.Success)
        {
            standard = "EDIFACT";
            version = match.Groups[1].Value.ToUpperInvariant();
            return;
        }

        match = EdifactBetaNamespaceRegex.Match(ns);
        if (match.Success)
        {
            standard = "EDIFACT";
            version = "Beta";
        }
    }

    private static SegmentDefinition BuildDefinition(Type type)
    {
        var inProgress = _inProgress ?? (_inProgress = new HashSet<Type>());
        if (!inProgress.Add(type))
        {
            // Cycle guard: a composite that (directly or indirectly) contains itself. Should not
            // happen in practice, but never recurse forever.
            return new SegmentDefinition { Id = GetId(type), Name = GetName(type), Origin = "derived" };
        }

        try
        {
            var id = GetId(type);
            var def = new SegmentDefinition { Id = id, Name = GetName(type), Origin = "derived" };

            var positioned = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new { Property = p, Position = p.GetCustomAttribute<PositionAttribute>() })
                .Where(x => x.Position != null)
                .OrderBy(x => x.Position.Position)
                .ToList();

            object baseline = TryCreateInstance(type);
            var mandatory = new HashSet<string>();
            var conditional = new HashSet<string>();

            if (baseline != null)
                CollectRequirementSignals(TryValidate(type, baseline), mandatory, conditional);

            var elements = new List<ElementDefinition>();
            foreach (var entry in positioned)
            {
                var elem = BuildElementSkeleton(entry.Property, entry.Position.Position, id);
                elements.Add(elem);

                if (baseline == null || elem.DataType == ElementDataType.Composite)
                    continue;

                var canonicalValue = CanonicalProbeValue(entry.Property.PropertyType);
                if (canonicalValue != null)
                {
                    var result = TryProbeSingle(type, entry.Property, canonicalValue);
                    ApplyLengthAndDateProbe(elem, entry.Property.Name, result);
                    CollectRequirementSignals(result, mandatory, conditional);
                }

                if (entry.Property.PropertyType == typeof(string))
                {
                    var result2 = TryProbeSingle(type, entry.Property, "9");
                    ApplyLengthAndDateProbe(elem, entry.Property.Name, result2);
                    CollectRequirementSignals(result2, mandatory, conditional);
                }
            }

            foreach (var elem in elements)
            {
                if (baseline == null)
                {
                    elem.Requirement = Requirement.Unknown;
                }
                else if (mandatory.Contains(elem.PropertyName))
                {
                    elem.Requirement = Requirement.Mandatory;
                }
                else if (conditional.Contains(elem.PropertyName))
                {
                    elem.Requirement = Requirement.Conditional;
                }
                else
                {
                    elem.Requirement = Requirement.Optional;
                }
            }

            def.Elements = elements;
            return def;
        }
        finally
        {
            inProgress.Remove(type);
        }
    }

    private static ElementDefinition BuildElementSkeleton(PropertyInfo prop, int position, string referencePrefix)
    {
        var elem = new ElementDefinition
        {
            Position = position,
            Reference = referencePrefix + position.ToString("D2"),
            Name = SplitWords(prop.Name),
            PropertyName = prop.Name,
            Origin = "derived",
        };

        SetCoarseType(elem, prop.PropertyType);

        if (elem.DataType == ElementDataType.Composite)
        {
            var nested = Cache.GetOrAdd(prop.PropertyType, BuildDefinition);
            elem.CompositeId = nested.Id;
            foreach (var component in nested.Elements)
                elem.Components.Add(component.Clone());
        }

        return elem;
    }

    private static string GetId(Type type)
    {
        var segmentAttribute = type.GetCustomAttribute<Segment>(true);
        if (segmentAttribute != null && !string.IsNullOrEmpty(segmentAttribute.Name))
            return segmentAttribute.Name;

        var name = type.Name;
        var underscore = name.IndexOf('_');
        return underscore >= 0 ? name.Substring(0, underscore) : name;
    }

    private static string GetName(Type type)
    {
        var name = type.Name;
        var underscore = name.IndexOf('_');
        var raw = underscore >= 0 ? name.Substring(underscore + 1) : name;
        return SplitWords(raw);
    }

    private static string SplitWords(string s)
    {
        return string.IsNullOrEmpty(s) ? s : WordSplitRegex.Replace(s, " ");
    }

    private static bool IsComponentType(Type t)
    {
        var current = t.BaseType;
        while (current != null)
        {
            if (current.Name == "EdiX12Component" || current.Name == "EdifactComponent")
                return true;
            current = current.BaseType;
        }
        return false;
    }

    private static void SetCoarseType(ElementDefinition elem, Type propType)
    {
        var under = Nullable.GetUnderlyingType(propType) ?? propType;

        if (under == typeof(string))
        {
            elem.DataType = ElementDataType.AlphaNumeric;
        }
        else if (under == typeof(int) || under == typeof(long) || under == typeof(short))
        {
            elem.DataType = ElementDataType.Numeric;
            elem.Decimals = 0;
        }
        else if (under == typeof(decimal) || under == typeof(double) || under == typeof(float))
        {
            elem.DataType = ElementDataType.Decimal;
        }
        else if (IsComponentType(under))
        {
            elem.DataType = ElementDataType.Composite;
        }
        else
        {
            elem.DataType = ElementDataType.Unknown;
        }
    }

    private static object CanonicalProbeValue(Type propType)
    {
        var under = Nullable.GetUnderlyingType(propType) ?? propType;

        if (under == typeof(string))
            return new string('X', 1000);
        if (under == typeof(int))
            return 1234567890;
        if (under == typeof(long))
            return 1234567890L;
        if (under == typeof(short))
            return short.MaxValue;
        if (under == typeof(decimal))
            return 1234567890.5m;
        if (under == typeof(double))
            return 1234567890.5d;
        if (under == typeof(float))
            return 1234567890.5f;

        return null;
    }

    private static object TryCreateInstance(Type type)
    {
        try
        {
            return Activator.CreateInstance(type);
        }
        catch
        {
            return null;
        }
    }

    private static ValidationResult TryValidate(Type type, object instance)
    {
        try
        {
            var method = type.GetMethod("Validate", BindingFlags.Public | BindingFlags.Instance);
            if (method == null)
                return null;
            return method.Invoke(instance, null) as ValidationResult;
        }
        catch
        {
            return null;
        }
    }

    private static ValidationResult TryProbeSingle(Type type, PropertyInfo prop, object value)
    {
        try
        {
            var instance = Activator.CreateInstance(type);
            prop.SetValue(instance, value);
            return TryValidate(type, instance);
        }
        catch
        {
            return null;
        }
    }

    private static void CollectRequirementSignals(ValidationResult result, HashSet<string> mandatory, HashSet<string> conditional)
    {
        if (result == null)
            return;

        foreach (var error in result.Errors)
        {
            if (error.PropertyName == null)
                continue;

            if (error.ErrorCode == ErrorCodes.Required)
                mandatory.Add(error.PropertyName);
            else if (Array.IndexOf(ConditionalErrorCodes, error.ErrorCode) >= 0)
                conditional.Add(error.PropertyName);
        }
    }

    private static void ApplyLengthAndDateProbe(ElementDefinition elem, string propertyName, ValidationResult result)
    {
        if (result == null)
            return;

        foreach (var error in result.Errors)
        {
            if (error.PropertyName != propertyName)
                continue;

            if (error.ErrorCode == ErrorCodes.OutOfRange)
            {
                elem.MinLength = ParseIntSafe(error.Data.Length > 1 ? error.Data[1] : null);
                elem.MaxLength = ParseIntSafe(error.Data.Length > 2 ? error.Data[2] : null);
            }
            else if (error.ErrorCode == ErrorCodes.ExactLength)
            {
                var length = ParseIntSafe(error.Data.Length > 1 ? error.Data[1] : null);
                elem.MinLength = length;
                elem.MaxLength = length;
            }
            else if (error.ErrorCode == ErrorCodes.DateIsNotValidFormat)
            {
                elem.DataType = ElementDataType.Date;
            }
            else if (error.ErrorCode == ErrorCodes.TimeIsNotValidFormat)
            {
                elem.DataType = ElementDataType.Time;
            }
        }
    }

    private static int? ParseIntSafe(object value)
    {
        if (value == null)
            return null;
        int result;
        return int.TryParse(value.ToString(), out result) ? result : (int?)null;
    }
}
