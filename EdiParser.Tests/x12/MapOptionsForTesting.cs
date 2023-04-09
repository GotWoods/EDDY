using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiParser.x12.Mapping;

namespace EdiParser.Tests.x12;

//
public static class MapOptionsForTesting
{
    public static MapOptions x12DefaultEndsWithNewline
    {
        get
        {
            return new MapOptions() { LineEnding = Environment.NewLine, Separator = "*", StandardsVersion = "8020", ComponentElementSeparator = ">"};
        }
    }

    public static MapOptions x12DefaultEndsWithTilde
    {
        get
        {
            return new MapOptions() { LineEnding = "~", Separator = "*", StandardsVersion = "8020", ComponentElementSeparator = ">" };
        }
    }
}