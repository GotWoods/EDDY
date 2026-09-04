namespace Eddy.Notepad.ViewModels;

/// <summary>
/// One data element of a segment, as shown in the detail grid.
/// For a composite element, <see cref="Components"/> holds the sub-elements
/// and <see cref="Value"/> holds the raw composite text.
/// </summary>
public sealed class ElementViewModel
{
    public ElementViewModel(string reference, int position, string name, string propertyName, string? value)
    {
        Reference = reference;
        Position = position;
        Name = name;
        PropertyName = propertyName;
        Value = value;
    }

    /// <summary>Element reference in EDI notation, e.g. "N101", or "C00101" for a component.</summary>
    public string Reference { get; }

    /// <summary>1-based element position within the segment (the [Position] attribute value).</summary>
    public int Position { get; }

    /// <summary>Human readable name derived from the property name, e.g. "Entity Identifier Code".</summary>
    public string Name { get; }

    /// <summary>The C# property name on the Eddy model, e.g. "EntityIdentifierCode".</summary>
    public string PropertyName { get; }

    /// <summary>The element's value as text, or null when the element is absent.</summary>
    public string? Value { get; }

    public bool HasValue => !string.IsNullOrEmpty(Value);

    public bool IsComposite => Components.Count > 0;

    public IReadOnlyList<ElementViewModel> Components { get; init; } = Array.Empty<ElementViewModel>();

    /// <summary>True when a diagnostic on the owning segment names this element.</summary>
    public bool HasError { get; init; }
}
