using System.Text.RegularExpressions;

namespace Eddy.Notepad.Services;

/// <summary>Turns C# identifier-style names into human readable labels.</summary>
public static class DisplayNames
{
    // Splits before an uppercase letter that follows a lowercase letter or digit ("entityCode" -> "entity Code"),
    // before the last uppercase letter of an acronym run that is followed by a lowercase letter ("HTTPCode" ->
    // "HTTP Code"), and before a digit that follows a letter ("Code2" -> "Code 2").
    private static readonly Regex Splitter = new(
        "(?<=[a-z0-9])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])|(?<=[A-Za-z])(?=[0-9])",
        RegexOptions.Compiled);

    /// <summary>"EntityIdentifierCode2" -> "Entity Identifier Code 2".</summary>
    public static string SplitPascalCase(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return string.Empty;

        return string.Join(" ", Splitter.Split(name));
    }
}
