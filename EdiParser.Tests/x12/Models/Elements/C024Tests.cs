using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C024Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "g6*or*ag*3c*ZV";

        var expected = new C024_RelatedCausesInformation()
        {
            RelatedCausesCode = "g6",
            RelatedCausesCode2 = "or",
            RelatedCausesCode3 = "ag",
            StateOrProvinceCode = "3c",
            CountryCode = "ZV",
        };

        var actual = Map.MapObject<C024_RelatedCausesInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("g6", true)]
    public void Validatation_RequiredRelatedCausesCode(string relatedCausesCode, bool isValidExpected)
    {
        var subject = new C024_RelatedCausesInformation();
        subject.RelatedCausesCode = relatedCausesCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}