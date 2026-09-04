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

    /// <summary>Standard data element number ("3035", "98"), from a loaded metadata pack. Null when unknown.</summary>
    public string? DataElementNumber { get; init; }

    public bool HasDataElementNumber => !string.IsNullOrEmpty(DataElementNumber);

    /// <summary>Formal data type label, e.g. "ID 1..3", "AN 1..35", "N0", "DT", "R 1..15". "" when unknown.</summary>
    public string DataTypeLabel { get; init; } = "";

    /// <summary>"M", "O", "C", or "" when unknown.</summary>
    public string Requirement { get; init; } = "";

    /// <summary>
    /// The meaning of <see cref="Value"/> for a coded element, from a loaded metadata pack's code list.
    /// Null when the element has no code list, or the value is not in it. "" when the value is a known,
    /// valid code with no description text.
    /// </summary>
    public string? CodeDescription { get; init; }

    /// <summary>Where this element's metadata came from: "derived", or the name of the pack that overlaid it.</summary>
    public string Origin { get; init; } = "derived";

    /// <summary>
    /// Text for the "Meaning" column: <see cref="CodeDescription"/> when it has text, "valid code" when the
    /// value is a known code with no description, "not in code list" when the value fails to match a loaded
    /// code list for an Identifier element, else "".
    /// </summary>
    public string Meaning =>
        CodeDescription switch
        {
            { Length: > 0 } text => text,
            "" => "valid code",
            _ => IsUnrecognizedCode ? "not in code list" : "",
        };

    /// <summary>True when <see cref="Meaning"/> is the "not in code list" warning, so the view can style it differently from a dimmed "valid code"/absent meaning.</summary>
    public bool IsUnrecognizedCode =>
        CodeDescription is null && HasValue && DataTypeLabel.StartsWith("ID", StringComparison.Ordinal);

    /// <summary>True when <see cref="Meaning"/> should render dimmed: everything except real description
    /// text and the "not in code list" warning.</summary>
    public bool MeaningIsDimmed => CodeDescription is not { Length: > 0 } && !IsUnrecognizedCode;
}
