using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class N7BTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N7B*8*A*BBB*CCC*DDD*nU3mAewBbfffi0xRHGfM8OuXGApbs0Pfn5RMap4C2Za3VX8qfJL38ahZFAN2u76Drn1xHpnbpjYgzUn";

        var expected = new N7B_AdditionalEquipmentDetails()
        {
            NumberOfTankCompartments = 8,
            LoadingOrDischargeLocationCode = "A",
            VesselMaterialCode = "BBB",
            GasketTypeCode = "CCC",
            TrailerLiningTypeCode = "DDD",
            ReferenceIdentification = "nU3mAewBbfffi0xRHGfM8OuXGApbs0Pfn5RMap4C2Za3VX8qfJL38ahZFAN2u76Drn1xHpnbpjYgzUn",
        };

        var actual = Map.MapObject<N7B_AdditionalEquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
}