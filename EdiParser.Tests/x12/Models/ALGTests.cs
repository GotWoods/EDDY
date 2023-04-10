using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ALGTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ALG*7*z*q**Tl";

        var expected = new ALG_Allergen
        {
            AssignedIdentification = "7",
            AllergenTypeCode = "z",
            YesNoConditionOrResponseCode = "q",
            ConditionIndicatorCode = "Tl"
        };

        var actual = Map.MapObject<ALG_Allergen>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("z", true)]
    public void Validatation_RequiredAllergenTypeCode(string allergenTypeCode, bool isValidExpected)
    {
        var subject = new ALG_Allergen();
        subject.YesNoConditionOrResponseCode = "q";
        subject.AllergenTypeCode = allergenTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("q", true)]
    public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
    {
        var subject = new ALG_Allergen();
        subject.AllergenTypeCode = "z";
        subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}