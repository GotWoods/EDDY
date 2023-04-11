using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C056Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "W*h*8";

        var expected = new C056_CompositeRaceOrEthnicityInformation()
        {
            RaceOrEthnicityCode = "W",
            CodeListQualifierCode = "h",
            IndustryCode = "8",
        };

        var actual = Map.MapObject<C056_CompositeRaceOrEthnicityInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("h", "8", true)]
    [InlineData("", "8", false)]
    [InlineData("h", "", false)]
    public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
    {
        var subject = new C056_CompositeRaceOrEthnicityInformation();
        subject.CodeListQualifierCode = codeListQualifierCode;
        subject.IndustryCode = industryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}