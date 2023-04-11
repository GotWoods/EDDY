using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C046Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "B3*da*vQ*M8*da";

        var expected = new C046_CompositeQualifierIdentifier()
        {
            RateValueQualifier = "B3",
            RateValueQualifier2 = "da",
            RateValueQualifier3 = "vQ",
            RateValueQualifier4 = "M8",
            RateValueQualifier5 = "da",
        };

        var actual = Map.MapObject<C046_CompositeQualifierIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("B3", true)]
    public void Validatation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
    {
        var subject = new C046_CompositeQualifierIdentifier();
        subject.RateValueQualifier = rateValueQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}