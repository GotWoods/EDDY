using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L5Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "L5*1*8*z*w*oDK*Y*9*L*Q*S";

        var expected = new L5_DescriptionMarksAndNumbers()

        {
            LadingLineItemNumber = 1,
            LadingDescription = "8",
            CommodityCode = "z",
            CommodityCodeQualifier = "w",
            PackagingCode = "oDK",
            MarksAndNumbers = "Y",
            MarksAndNumbersQualifier = "9",
            CommodityCodeQualifier2 = "L",
            CommodityCode2 = "Q",
            CompartmentIDCode = "S",
        };

        var actual = Map.MapObject<L5_DescriptionMarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_RequiredCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
    {
        var subject = new L5_DescriptionMarksAndNumbers();
        subject.CommodityCode = commodityCode;
        subject.CommodityCodeQualifier = commodityCodeQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
    {
        var subject = new L5_DescriptionMarksAndNumbers();
        subject.CommodityCodeQualifier = commodityCodeQualifier;
        subject.CommodityCode = commodityCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}