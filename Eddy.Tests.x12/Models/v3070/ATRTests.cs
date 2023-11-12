using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070.Composites;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ATRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATR*ht*6*nb*4**3*W*i*72*5Khq";

		var expected = new ATR_AnimalTestResult()
		{
			TestTypeCode = "ht",
			TestPeriodOrIntervalValue = 6,
			UnitOfTimePeriodOrInterval = "nb",
			MeasurementValue = 4,
			CompositeUnitOfMeasure = null,
			NonNumericTestValue = "3",
			Description = "W",
			YesNoConditionOrResponseCode = "i",
			SurfaceLayerPositionCode = "72",
			Time = "5Khq",
		};

		var actual = Map.MapObject<ATR_AnimalTestResult>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ht", true)]
	public void Validation_RequiredTestTypeCode(string testTypeCode, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestPeriodOrIntervalValue = 6;
		subject.UnitOfTimePeriodOrInterval = "nb";
		//Test Parameters
		subject.TestTypeCode = testTypeCode;
		//At Least one
		subject.MeasurementValue = 4;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 4;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "ht";
		subject.UnitOfTimePeriodOrInterval = "nb";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		//At Least one
		subject.MeasurementValue = 4;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 4;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nb", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "ht";
		subject.TestPeriodOrIntervalValue = 6;
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//At Least one
		subject.MeasurementValue = 4;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 4;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", true)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "ht";
		subject.TestPeriodOrIntervalValue = 6;
		subject.UnitOfTimePeriodOrInterval = "nb";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();

        if (subject.MeasurementValue == null)
            subject.NonNumericTestValue = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", false)]

	[InlineData(0, "3", true)]
	public void Validation_AtLeastOneMeasurementValue(decimal measurementValue, string nonNumericTestValue, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "ht";
		subject.TestPeriodOrIntervalValue = 6;
		subject.UnitOfTimePeriodOrInterval = "nb";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.NonNumericTestValue = nonNumericTestValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
