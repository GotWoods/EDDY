using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C064Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "M*Q";

        var expected = new C064_ServiceType()
        {
            IndustryCode = "M",
            IndustryCode2 = "Q",
        };

        var actual = Map.MapObject<C064_ServiceType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("M", true)]
    public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
    {
        var subject = new C064_ServiceType();
        subject.IndustryCode = industryCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}