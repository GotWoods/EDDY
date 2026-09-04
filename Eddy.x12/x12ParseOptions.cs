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
}
