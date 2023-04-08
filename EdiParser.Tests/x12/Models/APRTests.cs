using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class APRTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "APR*7*g5Ht0vO*9929f6F";

        var expected = new APR_AssociationOfAmericanRailroadsPoolCodeRestrictions
        {
            YesNoConditionOrResponseCode = "7",
            AssociationOfAmericanRailroadsAARPoolCode = "g5Ht0vO",
            AssociationOfAmericanRailroadsAARPoolCode2 = "9929f6F"
        };

        var actual = Map.MapObject<APR_AssociationOfAmericanRailroadsPoolCodeRestrictions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("7", true)]
    public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
    {
        var subject = new APR_AssociationOfAmericanRailroadsPoolCodeRestrictions();
        subject.AssociationOfAmericanRailroadsAARPoolCode = "g5Ht0vO";
        subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("g5Ht0vO", true)]
    public void Validatation_RequiredAssociationOfAmericanRailroadsAARPoolCode(string associationOfAmericanRailroadsAARPoolCode, bool isValidExpected)
    {
        var subject = new APR_AssociationOfAmericanRailroadsPoolCodeRestrictions();
        subject.YesNoConditionOrResponseCode = "7";
        subject.AssociationOfAmericanRailroadsAARPoolCode = associationOfAmericanRailroadsAARPoolCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}