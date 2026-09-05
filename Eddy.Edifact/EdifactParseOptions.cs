using Eddy.Core.Validation;

namespace Eddy.Edifact;

/// <summary>Controls how <see cref="EdiFactDocument.Parse(string, EdifactParseOptions)"/> reacts to
/// problems in the input. The default (non-lenient) behaviour matches
/// <see cref="EdiFactDocument.Parse(string)"/>: well-formed input parses normally, and content the parser
/// cannot make sense of throws <see cref="Eddy.Core.InvalidFileFormatException"/>.</summary>
public class EdifactParseOptions
{
    /// <summary>When true, the parser never throws for a content problem (an unknown segment, a segment
    /// outside any message, a trailer without a header, a missing trailer at end of input, ...). Each
    /// problem is instead recorded as a <see cref="Eddy.Core.Validation.ValidationResult"/> and parsing
    /// continues. Defaults to false.</summary>
    public bool Lenient { get; set; }

    /// <summary>
    /// When not Off, every content segment's element values (including composite components) are checked
    /// against any code list loaded into <see cref="Eddy.Core.Metadata.MetadataCatalog.Default"/> for that
    /// element's data element number, after the segment's own Validate() runs. Elements with no
    /// CodeListId, or whose CodeListId has no code list loaded, are unaffected. Defaults to Off.
    /// </summary>
    public CodeListChecking CodeListChecking { get; set; } = CodeListChecking.Off;
}
