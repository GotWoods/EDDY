using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ASTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AST*c*1*4riCYdWT*3*gF*v1DuSo2c*9*a0*PiN7hQVq*2*3X";

        var expected = new AST_AnimalReproductiveStatus
        {
            YesNoConditionOrResponseCode = "c",
            ReferenceIdentification = "1",
            Date = "4riCYdWT",
            TestPeriodOrIntervalValue = 3,
            UnitOfTimePeriodOrIntervalCode = "gF",
            Date2 = "v1DuSo2c",
            TestPeriodOrIntervalValue2 = 9,
            UnitOfTimePeriodOrIntervalCode2 = "a0",
            Date3 = "PiN7hQVq",
            TestPeriodOrIntervalValue3 = 2,
            UnitOfTimePeriodOrIntervalCode3 = "3X"
        };

        var actual = Map.MapObject<AST_AnimalReproductiveStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("c", true)]
    public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
    {
        var subject = new AST_AnimalReproductiveStatus();
        subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(3, "gF", true)]
    [InlineData(0, "gF", false)]
    [InlineData(3, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
    {
        var subject = new AST_AnimalReproductiveStatus();
        subject.YesNoConditionOrResponseCode = "c";
        if (testPeriodOrIntervalValue > 0)
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "a0", true)]
    [InlineData(0, "a0", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
    {
        var subject = new AST_AnimalReproductiveStatus();
        subject.YesNoConditionOrResponseCode = "c";
        if (testPeriodOrIntervalValue2 > 0)
            subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
        subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(2, "3X", true)]
    [InlineData(0, "3X", false)]
    [InlineData(2, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
    {
        var subject = new AST_AnimalReproductiveStatus();
        subject.YesNoConditionOrResponseCode = "c";
        if (testPeriodOrIntervalValue3 > 0)
            subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
        subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}