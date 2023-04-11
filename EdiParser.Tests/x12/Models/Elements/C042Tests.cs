using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C042Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "L*U";

        var expected = new C042_AdjustmentIdentifier()
        {
            IndustryCode = "L",
            ReferenceIdentification = "U",
        };

        var actual = Map.MapObject<C042_AdjustmentIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("L", true)]
    public void Validatation_RequiredIndustryCode(string industryCode, bool isValidExpected)
    {
        var subject = new C042_AdjustmentIdentifier();
        subject.IndustryCode = industryCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}