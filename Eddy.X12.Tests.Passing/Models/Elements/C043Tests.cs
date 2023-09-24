using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C043Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "R*H*MU*e";

        var expected = new C043_HealthCareClaimStatus()
        {
            IndustryCode = "R",
            IndustryCode2 = "H",
            EntityIdentifierCode = "MU",
            CodeListQualifierCode = "e",
        };

        var actual = Map.MapObject<C043_HealthCareClaimStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("R", true)]
    public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
    {
        var subject = new C043_HealthCareClaimStatus();
        subject.IndustryCode2 = "H";
        subject.IndustryCode = industryCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("H", true)]
    public void Validation_RequiredIndustryCode2(string industryCode2, bool isValidExpected)
    {
        var subject = new C043_HealthCareClaimStatus();
        subject.IndustryCode = "R";
        subject.IndustryCode2 = industryCode2;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}