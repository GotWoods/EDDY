using System;
using Eddy.x12.Models;

namespace Eddy.x12.Mapping;

public class MapOptions
{
    public string LineEnding { get; set; }
    public string Separator { get; set; }
    public string StandardsVersion { get; set; }
    public string ComponentElementSeparator { get; set; }

    /// <summary>Builds the MapOptions an ISA header implies: data element separator, component element
    /// separator, segment terminator and standards version, exactly as the parser derives them while
    /// reading an interchange.</summary>
    public static MapOptions FromInterchangeHeader(GenericInterchangeControlHeader header)
    {
        if (header == null)
            throw new ArgumentNullException(nameof(header));

        return new MapOptions
        {
            Separator = header.DataElementSeparator.ToString(),
            ComponentElementSeparator = header.ComponentDataElementSeparator,
            LineEnding = header.ElementSeparator.ToString(),
            StandardsVersion = header.InterchangeControlVersionNumberCode + "0"
        };
    }
}