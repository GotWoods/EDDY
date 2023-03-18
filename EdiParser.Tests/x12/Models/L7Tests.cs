using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class L7Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "L7*p*r*C*q*H*8*yp*k*FDZK*Ys29jEQe*5*H*N*B*LR*tK";

        var expected = new L7_TariffReference()
        {
            LadingLineItemNumber = "p",
            TariffAgencyCode = "r",
            TariffNumber = "C",
            TariffSectionNumber = "q",
            TariffItemNumber = "H",
            TariffItemPart = "8",
            FreightClassCode = "yp",
            TariffSupplementIdentifier = "k",
            ExParte = "FDZK",
            Date = "Ys29jEQe",
            RateBasisNumber = "5",
            TariffColumn = "H",
            TariffDistance = "N",
            DistanceQualifier = "B",
            CityName = "LR",
            StateOrProvinceCode = "tK",
        };

        var actual = Map.MapObject<L7_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
}