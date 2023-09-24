using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class INGTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ING*i**7*y*Z*e";

        var expected = new ING_Ingredients
        {
            AssignedIdentification = "i",
            CompositeIngredientInformation = null,
            PercentDecimalFormat = 7,
            YesNoConditionOrResponseCode = "y",
            YesNoConditionOrResponseCode2 = "Z",
            YesNoConditionOrResponseCode3 = "e"
        };

        var actual = Map.MapObject<ING_Ingredients>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("i", true)]
    public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
    {
        var subject = new ING_Ingredients();
        subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
        subject.AssignedIdentification = assignedIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("AB", true)]
    public void Validation_RequiredCompositeIngredientInformation(string compositeIngredientInformation, bool isValidExpected)
    {
        var subject = new ING_Ingredients();
        subject.AssignedIdentification = "i";

        if (compositeIngredientInformation != "")
            subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation { FreeFormMessageText = compositeIngredientInformation };
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}