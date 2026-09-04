using System.Collections.Generic;

namespace Eddy.Core.Metadata;

/// <summary>Everything known about one element position of a segment or composite.</summary>
public class ElementDefinition
{
    /// <summary>1-based position, the same number as the [Position] attribute.</summary>
    public int Position { get; set; }

    /// <summary>EDI reference such as "N101" or "C08201".</summary>
    public string Reference { get; set; }

    /// <summary>Human readable name, e.g. "Entity Identifier Code".</summary>
    public string Name { get; set; }

    /// <summary>The model property backing this element, when derived from a type.</summary>
    public string PropertyName { get; set; }

    /// <summary>Standard data element number, e.g. "98" (X12) or "3035" (EDIFACT). Null when unknown.</summary>
    public string DataElementNumber { get; set; }

    public ElementDataType DataType { get; set; }

    /// <summary>Implied decimals for Numeric types (N2 = 2). Null when not applicable or unknown.</summary>
    public int? Decimals { get; set; }

    public int? MinLength { get; set; }

    public int? MaxLength { get; set; }

    public Requirement Requirement { get; set; }

    /// <summary>Identifier of the code list that applies, normally the data element number. Null when none.</summary>
    public string CodeListId { get; set; }

    /// <summary>Composite identifier such as "C082" when DataType is Composite.</summary>
    public string CompositeId { get; set; }

    /// <summary>Component elements when DataType is Composite; empty otherwise.</summary>
    public List<ElementDefinition> Components { get; set; } = new List<ElementDefinition>();

    /// <summary>Where the values came from: "derived", or the name of the pack that last overlaid them.</summary>
    public string Origin { get; set; }

    public override string ToString() => $"{Reference} {Name}";
}

/// <summary>A segment (or composite) definition: its identifier, name and elements in position order.</summary>
public class SegmentDefinition
{
    /// <summary>"X12" or "EDIFACT".</summary>
    public string Standard { get; set; }

    /// <summary>Normalised version: "004010" for X12, "D96A" for EDIFACT.</summary>
    public string Version { get; set; }

    /// <summary>Segment identifier such as "N1", or composite identifier such as "C082".</summary>
    public string Id { get; set; }

    public string Name { get; set; }

    public List<ElementDefinition> Elements { get; set; } = new List<ElementDefinition>();

    public string Origin { get; set; }

    public override string ToString() => $"{Id} {Name}";
}

/// <summary>A data dictionary entry: what a data element number means independent of any segment.</summary>
public class DataElementDefinition
{
    public string Number { get; set; }
    public string Name { get; set; }
    public ElementDataType DataType { get; set; }
    public int? Decimals { get; set; }
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
}
