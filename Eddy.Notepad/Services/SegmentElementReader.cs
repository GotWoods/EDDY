using System.Reflection;
using Eddy.Core.Metadata;
using Eddy.Core.Validation;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Services;

/// <summary>
/// Builds the element grid (<see cref="ElementViewModel"/> list) for one Eddy model object (an X12
/// EdiX12Segment/EdiX12Component or an EDIFACT EdifactSegment/EdifactComponent), from
/// <see cref="MetadataCatalog.Describe"/>: positions, references, names and composite structure come
/// from there (derived from the model's [Position] properties, overlaid with any loaded metadata pack);
/// property values still come from the model instance. See README.md, "Loader contract", rule 5.
/// </summary>
public sealed class SegmentElementReader
{
    private readonly MetadataCatalog _catalog;

    public SegmentElementReader(MetadataCatalog catalog)
    {
        _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
    }

    /// <summary>
    /// Reads the elements of <paramref name="model"/> (a segment or a header). <paramref name="code"/> is the
    /// prefix used to build element references ("N1" -> "N101", "N102", ...). <paramref name="errors"/>,
    /// when given, marks an element HasError when a diagnostic on the owning segment names its PropertyName
    /// or its ElementPosition (rule 8; see Eddy.Core.Validation.Error).
    /// </summary>
    public IReadOnlyList<ElementViewModel> Read(object model, string code, IReadOnlyList<Error>? errors = null)
    {
        var errorList = errors ?? Array.Empty<Error>();
        var definition = _catalog.Describe(model.GetType());

        if (definition.Elements.Count > 0)
            return BuildElements(model, definition.Elements, code, definition.Standard, definition.Version, errorList);

        // ISA (and any other header with no [Position] attributes): declaration order, string/int properties only.
        return ReadDeclarationOrder(model, code, errorList);
    }

    private List<ElementViewModel> BuildElements(
        object owner, List<ElementDefinition> definitions, string parentReference, string? standard, string? version, IReadOnlyList<Error> errors)
    {
        var result = new List<ElementViewModel>(definitions.Count);
        for (var i = 0; i < definitions.Count; i++)
            result.Add(BuildElement(owner, definitions[i], i + 1, parentReference, standard, version, errors));

        return result;
    }

    private ElementViewModel BuildElement(
        object owner, ElementDefinition definition, int rank, string parentReference, string? standard, string? version, IReadOnlyList<Error> errors)
    {
        var reference = parentReference + rank.ToString("D2");
        var property = owner.GetType().GetProperty(definition.PropertyName, BindingFlags.Public | BindingFlags.Instance);
        var rawValue = property?.GetValue(owner);
        var hasError = HasError(errors, definition.PropertyName, definition.Position);
        var dataTypeLabel = FormatType(definition.DataType, definition.Decimals, definition.MinLength, definition.MaxLength);
        var requirement = FormatRequirement(definition.Requirement);

        if (definition.DataType == ElementDataType.Composite)
        {
            var component = rawValue ?? (property is not null ? Activator.CreateInstance(property.PropertyType) : null);
            var subElements = component is not null
                ? BuildElements(component, definition.Components, reference, standard, version, errors)
                : new List<ElementViewModel>();
            var filled = subElements.Where(e => e.HasValue).Select(e => e.Value!).ToList();
            var value = filled.Count > 0 ? string.Join(" ", filled) : null;

            return new ElementViewModel(reference, definition.Position, definition.Name, definition.PropertyName, value)
            {
                Components = subElements,
                HasError = hasError,
                DataTypeLabel = dataTypeLabel,
                Requirement = requirement,
                Origin = definition.Origin,
            };
        }

        var textValue = rawValue?.ToString();
        var elementValue = string.IsNullOrEmpty(textValue) ? null : textValue;

        string? codeDescription = null;
        if (definition.CodeListId is not null && elementValue is not null && standard is not null && version is not null)
            codeDescription = _catalog.DescribeCode(standard, version, definition.CodeListId, elementValue);

        return new ElementViewModel(reference, definition.Position, definition.Name, definition.PropertyName, elementValue)
        {
            HasError = hasError,
            DataElementNumber = definition.DataElementNumber,
            DataTypeLabel = dataTypeLabel,
            Requirement = requirement,
            CodeDescription = codeDescription,
            Origin = definition.Origin,
        };
    }

    private static List<ElementViewModel> ReadDeclarationOrder(object model, string code, IReadOnlyList<Error> errors)
    {
        var properties = model.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetIndexParameters().Length == 0)
            .Where(p => p.PropertyType == typeof(string) || p.PropertyType == typeof(int) || p.PropertyType == typeof(int?))
            .ToList();

        var result = new List<ElementViewModel>(properties.Count);
        for (var i = 0; i < properties.Count; i++)
        {
            var property = properties[i];
            var position = i + 1;
            var reference = code + position.ToString("D2");
            var name = DisplayNames.SplitPascalCase(property.Name);
            var value = property.GetValue(model)?.ToString();
            var hasError = HasError(errors, property.Name, position);
            result.Add(new ElementViewModel(reference, position, name, property.Name, string.IsNullOrEmpty(value) ? null : value) { HasError = hasError });
        }

        return result;
    }

    /// <summary>
    /// An element is in error when a diagnostic on the owning segment names its C# PropertyName, or was
    /// tagged with this element's [Position] value (Eddy.Core.Validation.BasicValidator tags both when it
    /// can; some structural checks only set one or the other).
    /// </summary>
    private static bool HasError(IReadOnlyList<Error> errors, string propertyName, int position)
    {
        for (var i = 0; i < errors.Count; i++)
        {
            var error = errors[i];
            if (error.PropertyName == propertyName || error.ElementPosition == position)
                return true;
        }

        return false;
    }

    /// <summary>"ID 1..3", "AN 1..35", "N0" (Numeric with 0 implied decimals), "R 1..15", "DT", "TM", "B", or "" when unknown.</summary>
    private static string FormatType(ElementDataType type, int? decimals, int? minLength, int? maxLength)
    {
        var range = minLength.HasValue && maxLength.HasValue ? $" {minLength}..{maxLength}"
            : minLength.HasValue ? $" {minLength}+"
            : maxLength.HasValue ? $" ..{maxLength}"
            : "";

        return type switch
        {
            ElementDataType.Identifier => "ID" + range,
            ElementDataType.AlphaNumeric => "AN" + range,
            ElementDataType.Numeric => "N" + (decimals ?? 0),
            ElementDataType.Decimal => "R" + range,
            ElementDataType.Date => "DT",
            ElementDataType.Time => "TM",
            ElementDataType.Binary => "B" + range,
            _ => "",
        };
    }

    private static string FormatRequirement(Requirement requirement) => requirement switch
    {
        Requirement.Mandatory => "M",
        Requirement.Optional => "O",
        Requirement.Conditional => "C",
        _ => "",
    };
}
