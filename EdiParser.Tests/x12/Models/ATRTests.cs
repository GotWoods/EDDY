using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ATRTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ATR*1R*4*y5*3**5*K*J*Zm*UjRg";

        var expected = new ATR_AnimalTestResult
        {
            TestTypeCode = "1R",
            TestPeriodOrIntervalValue = 4,
            UnitOfTimePeriodOrIntervalCode = "y5",
            MeasurementValue = 3,
            //CompositeUnitOfMeasure = "",
            NonNumericTestValue = "5",
            Description = "K",
            YesNoConditionOrResponseCode = "J",
            SurfaceLayerPositionCode = "Zm",
            Time = "UjRg"
        };

        var actual = Map.MapObject<ATR_AnimalTestResult>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("1R", true)]
    public void Validatation_RequiredTestTypeCode(string testTypeCode, bool isValidExpected)
    {
        var subject = new ATR_AnimalTestResult();
        subject.TestPeriodOrIntervalValue = 4;
        subject.UnitOfTimePeriodOrIntervalCode = "y5";
        subject.TestTypeCode = testTypeCode;
        subject.NonNumericTestValue = "ABC";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(4, true)]
    public void Validatation_RequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, bool isValidExpected)
    {
        var subject = new ATR_AnimalTestResult();
        subject.TestTypeCode = "1R";
        subject.UnitOfTimePeriodOrIntervalCode = "y5";
        if (testPeriodOrIntervalValue > 0)
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
        subject.NonNumericTestValue = "ABC";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("y5", true)]
    public void Validatation_RequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
    {
        var subject = new ATR_AnimalTestResult();
        subject.TestTypeCode = "1R";
        subject.TestPeriodOrIntervalValue = 4;
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
        subject.NonNumericTestValue = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    //TODO: composite test
    // [Theory]
    // [InlineData(0,"", true)]
    // [InlineData(3, "", true)]
    // [InlineData(0, "", false)]
    // [InlineData(3, "", false)]
    // public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, C001_CompositeUnitOfMeasure compositeUnitOfMeasure, bool isValidExpected)
    // {
    // 	var subject = new ATR_AnimalTestResult();
    // 	subject.TestTypeCode = "1R";
    // 	subject.TestPeriodOrIntervalValue = 4;
    // 	subject.UnitOfTimePeriodOrIntervalCode = "y5";
    // 	if (measurementValue > 0)
    // 	subject.MeasurementValue = measurementValue;
    // 	subject.CompositeUnitOfMeasure = compositeUnitOfMeasure;
    //
    // 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    // }

    [Theory]
    [InlineData(0, "", false)]
    [InlineData(3, "5", true)]
    [InlineData(0, "5", true)]
    [InlineData(3, "", true)]
    public void Validation_AtLeastOneMeasurementValue(decimal measurementValue, string nonNumericTestValue, bool isValidExpected)
    {
        var subject = new ATR_AnimalTestResult();
        subject.TestTypeCode = "1R";
        subject.TestPeriodOrIntervalValue = 4;
        subject.UnitOfTimePeriodOrIntervalCode = "y5";
        if (measurementValue > 0)
            subject.MeasurementValue = measurementValue;
        subject.NonNumericTestValue = nonNumericTestValue;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
}