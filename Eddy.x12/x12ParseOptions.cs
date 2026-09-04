using Eddy.Core.Validation;

namespace Eddy.x12;

public class x12ParseOptions
{
    /// <summary>
    /// When false (the default), Parse throws InvalidFileFormatException on malformed input, matching
    /// the historical behaviour of x12Document.Parse(string).
    /// When true, Parse never throws for content problems: it records a ValidationResult describing the
    /// problem and keeps going, producing as complete a document as it can.
    /// </summary>
    public bool Lenient { get; set; } = false;

    /// <summary>
    /// When not Off, every segment's element values (including composite components) are checked against
    /// any code list loaded into <see cref="Eddy.Core.Metadata.MetadataCatalog.Default"/> for that
    /// element's data element number, after the segment's own Validate() runs. Elements with no
    /// CodeListId, or whose CodeListId has no code list loaded, are unaffected. Defaults to Off.
    /// </summary>
    public CodeListChecking CodeListChecking { get; set; } = CodeListChecking.Off;
}
