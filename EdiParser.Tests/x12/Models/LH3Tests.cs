using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class LH3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LH3*4q5P19tbHqr9vYJusEEeTi7D2*J*ZpQ*b";

        var expected = new LH3_HazardousMaterialShippingNameInformation()
        {
            HazardousMaterialShippingName = "4q5P19tbHqr9vYJusEEeTi7D2",
            HazardousMaterialShippingNameQualifier = "J",
            NOSIndicatorCode = "ZpQ",
            YesNoConditionOrResponseCode = "b",
        };

        var actual = Map.MapObject<LH3_HazardousMaterialShippingNameInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("1", "2", true)]
    [InlineData("", "2", false)]
    [InlineData("1", "", false)]
    public void Validation_AllAreRequiredHazardousMaterialShippingName(string hazardousMaterialShippingName, string hazardousMaterialShippingNameQualifier, bool isValidExpected)
    {
        var subject = new LH3_HazardousMaterialShippingNameInformation();
        subject.HazardousMaterialShippingName = hazardousMaterialShippingName;
        subject.HazardousMaterialShippingNameQualifier = hazardousMaterialShippingNameQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}