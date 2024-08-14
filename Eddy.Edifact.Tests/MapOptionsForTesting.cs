using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddy.Edifact.Mapping;

namespace Eddy.Edifact.Tests
{
    public class MapOptionsForTesting
    {
        public static MapOptions EdifactDefaultEndsWithSingleQuote
        {
            get
            {
                return new MapOptions() { LineEnding = "'", Separator = "+", StandardsVersion = "D21A", ComponentElementSeparator = ":" };
            }
        }
    }
}
