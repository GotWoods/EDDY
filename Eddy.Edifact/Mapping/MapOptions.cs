namespace Eddy.Edifact.Mapping;

public class MapOptions
{
    /// <summary>The segment terminator. Despite the name this is not a line ending in the text sense -
    /// EDIFACT segments are not required to be on their own line - but the property predates that
    /// understanding and is kept for compatibility.</summary>
    public string LineEnding { get; set; } = "'";
    public string Separator { get; set; } = "+";
    public string StandardsVersion { get; set; } = "";
    public string ComponentElementSeparator { get; set; } = ":";

    /// <summary>Escapes the character that follows it (a separator, the terminator, or itself) so it is
    /// read as literal data instead of a delimiter. UNA position 4; default '?'.</summary>
    public string ReleaseCharacter { get; set; } = "?";

    /// <summary>Character used as the decimal mark in numeric values. UNA position 3; default '.'.</summary>
    public string DecimalMark { get; set; } = ".";

    /// <summary>Reserved for future use / repetition separator. UNA position 5; default ' ' (unused).</summary>
    public string RepetitionSeparator { get; set; } = " ";
}