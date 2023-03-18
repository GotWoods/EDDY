using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class N7ATests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N7A*AA*0*9*BBB*2*0*CC*DD*EE";

        var expected = new N7A_AccessorialEquipmentDetails()
        {
            LoadOrDeviceCode = "AA",
            Length = 0,
            Diameter = 9,
            HoseTypeCode = "BBB",
            Diameter2 = 2,
            Diameter3 = 0,
            InletOrOutletMaterialTypeCode = "CC",
            InletOrOutletFittingTypeCode = "DD",
            MiscellaneousEquipmentCode = "EE",
        };

        var actual = Map.MapObject<N7A_AccessorialEquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
}