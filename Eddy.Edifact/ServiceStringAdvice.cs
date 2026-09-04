using Eddy.Core;

namespace Eddy.Edifact;

/// <summary>Represents the UNA service string advice segment: the six characters that define the
/// delimiters used by the rest of the interchange. When a file has no UNA segment, EDIFACT defines
/// these as the defaults below (see ISO 9735).</summary>
public class ServiceStringAdvice : ISourceTracked
{
    public ServiceStringAdvice()
    {
    }

    public ServiceStringAdvice(char componentDataElementSeparator, char dataElementSeparator, char decimalMark,
        char releaseCharacter, char repetitionSeparator, char segmentTerminator)
    {
        ComponentDataElementSeparator = componentDataElementSeparator;
        DataElementSeparator = dataElementSeparator;
        DecimalMark = decimalMark;
        ReleaseCharacter = releaseCharacter;
        RepetitionSeparator = repetitionSeparator;
        SegmentTerminator = segmentTerminator;
    }

    /// <summary>UNA position 1. Default ':'.</summary>
    public char ComponentDataElementSeparator { get; set; } = ':';

    /// <summary>UNA position 2. Default '+'.</summary>
    public char DataElementSeparator { get; set; } = '+';

    /// <summary>UNA position 3. Default '.'.</summary>
    public char DecimalMark { get; set; } = '.';

    /// <summary>UNA position 4 - escapes the character following it. Default '?'.</summary>
    public char ReleaseCharacter { get; set; } = '?';

    /// <summary>UNA position 5 - reserved for future use / repetition separator. Default ' ' (unused).</summary>
    public char RepetitionSeparator { get; set; } = ' ';

    /// <summary>UNA position 6. Default '\''.</summary>
    public char SegmentTerminator { get; set; } = '\'';

    public SegmentSource Source { get; set; }

    public override string ToString()
    {
        return "UNA" + ComponentDataElementSeparator + DataElementSeparator + DecimalMark + ReleaseCharacter +
               RepetitionSeparator + SegmentTerminator;
    }
}
