using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.Notepad.ViewModels;
using Eddy.x12.Models;

namespace Eddy.Notepad.Services;

/// <summary>
/// Builds the element grid (<see cref="ElementViewModel"/> list) for one Eddy model object, by
/// reflecting over its public properties. See README.md, "Loader contract", rule 7.
/// </summary>
public static class SegmentElementReader
{
    /// <summary>
    /// Reads the elements of <paramref name="model"/> (a segment or a header). <paramref name="code"/> is the
    /// prefix used to build element references ("N1" -> "N101", "N102", ...). <paramref name="errorMessages"/>,
    /// when given, marks an element HasError when a message contains its PropertyName (rule 8).
    /// </summary>
    public static IReadOnlyList<ElementViewModel> Read(object model, string code, IReadOnlyList<string>? errorMessages = null)
    {
        var byPosition = ReadPositioned(model, code, errorMessages ?? Array.Empty<string>());
        if (byPosition.Count > 0)
            return byPosition;

        // ISA (and any other header with no [Position] attributes): declaration order, string/int properties only.
        return ReadDeclarationOrder(model, code, errorMessages ?? Array.Empty<string>());
    }

    private static List<ElementViewModel> ReadPositioned(object model, string parentReference, IReadOnlyList<string> errorMessages)
    {
        var ordered = model.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(p => (Property: p, Attribute: p.GetCustomAttribute<PositionAttribute>()))
            .Where(x => x.Attribute is not null)
            .OrderBy(x => x.Attribute!.Position)
            .ToList();

        var result = new List<ElementViewModel>(ordered.Count);
        for (var i = 0; i < ordered.Count; i++)
        {
            var (property, attribute) = ordered[i];
            result.Add(BuildElement(model, property, attribute!.Position, i + 1, parentReference, errorMessages));
        }

        return result;
    }

    private static List<ElementViewModel> ReadDeclarationOrder(object model, string code, IReadOnlyList<string> errorMessages)
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
            var hasError = HasError(errorMessages, property.Name);
            result.Add(new ElementViewModel(reference, position, name, property.Name, string.IsNullOrEmpty(value) ? null : value) { HasError = hasError });
        }

        return result;
    }

    private static ElementViewModel BuildElement(object owner, PropertyInfo property, int rawPosition, int rank, string parentReference, IReadOnlyList<string> errorMessages)
    {
        var reference = parentReference + rank.ToString("D2");
        var name = DisplayNames.SplitPascalCase(property.Name);
        var rawValue = property.GetValue(owner);
        var underlyingType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        var hasError = HasError(errorMessages, property.Name);

        if (typeof(EdiX12Component).IsAssignableFrom(underlyingType))
        {
            var component = (rawValue as EdiX12Component) ?? (EdiX12Component)Activator.CreateInstance(underlyingType)!;
            var subElements = ReadPositioned(component, reference, errorMessages);
            var filled = subElements.Where(e => e.HasValue).Select(e => e.Value).ToList();
            var value = filled.Count > 0 ? string.Join(" ", filled) : null;
            return new ElementViewModel(reference, rawPosition, name, property.Name, value) { Components = subElements, HasError = hasError };
        }

        var textValue = rawValue?.ToString();
        return new ElementViewModel(reference, rawPosition, name, property.Name, string.IsNullOrEmpty(textValue) ? null : textValue) { HasError = hasError };
    }

    private static bool HasError(IReadOnlyList<string> errorMessages, string propertyName)
    {
        if (errorMessages.Count == 0)
            return false;

        for (var i = 0; i < errorMessages.Count; i++)
        {
            if (errorMessages[i].Contains(propertyName, StringComparison.Ordinal))
                return true;
        }

        return false;
    }
}
