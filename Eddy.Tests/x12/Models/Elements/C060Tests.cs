using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C060Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "v*G";

        var expected = new C060_QuestionAndAnswer()
        {
            AssignedIdentification = "v",
            YesNoConditionOrResponseCode = "G",
        };

        var actual = Map.MapObject<C060_QuestionAndAnswer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("v", true)]
    public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
    {
        var subject = new C060_QuestionAndAnswer();
        subject.YesNoConditionOrResponseCode = "G";
        subject.AssignedIdentification = assignedIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("G", true)]
    public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
    {
        var subject = new C060_QuestionAndAnswer();
        subject.AssignedIdentification = "v";
        subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}