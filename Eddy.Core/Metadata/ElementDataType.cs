namespace Eddy.Core.Metadata;

/// <summary>Formal data type of an element, as the standards define it.</summary>
public enum ElementDataType
{
    Unknown,
    /// <summary>AN: free text.</summary>
    AlphaNumeric,
    /// <summary>ID: a code from a code list.</summary>
    Identifier,
    /// <summary>N, N0..N9: integer with implied decimals (see ElementDefinition.Decimals).</summary>
    Numeric,
    /// <summary>R: decimal number with an explicit decimal point.</summary>
    Decimal,
    /// <summary>DT: date.</summary>
    Date,
    /// <summary>TM: time.</summary>
    Time,
    /// <summary>B: binary.</summary>
    Binary,
    /// <summary>A composite made of component elements.</summary>
    Composite
}

/// <summary>Whether an element must be present.</summary>
public enum Requirement
{
    Unknown,
    Mandatory,
    Optional,
    Conditional
}
