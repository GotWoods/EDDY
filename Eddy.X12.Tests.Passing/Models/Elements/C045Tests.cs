using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C045Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "2f*Zd*Dv*la*aY";

        var expected = new C045_ConditionsIndicated()
        {
            ConditionIndicatorCode = "2f",
            ConditionIndicatorCode2 = "Zd",
            ConditionIndicatorCode3 = "Dv",
            ConditionIndicatorCode4 = "la",
            ConditionIndicatorCode5 = "aY",
        };

        var actual = Map.MapObject<C045_ConditionsIndicated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("2f", true)]
    public void Validation_RequiredConditionIndicatorCode(string conditionIndicatorCode, bool isValidExpected)
    {
        var subject = new C045_ConditionsIndicated();
        subject.ConditionIndicatorCode = conditionIndicatorCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}