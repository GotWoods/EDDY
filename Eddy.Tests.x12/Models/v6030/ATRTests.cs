using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030.Composites;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ATRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATR*qQ*4*o8*3**7*o*b*t7*Z8GZ";

		var expected = new ATR_AnimalTestResult()
		{
			TestTypeCode = "qQ",
			TestPeriodOrIntervalValue = 4,
			UnitOfTimePeriodOrIntervalCode = "o8",
			MeasurementValue = 3,
			CompositeUnitOfMeasure = null,
			NonNumericTestValue = "7",
			Description = "o",
			YesNoConditionOrResponseCode = "b",
			SurfaceLayerPositionCode = "t7",
			Time = "Z8GZ",
		};

		var actual = Map.MapObject<ATR_AnimalTestResult>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qQ", true)]
	public void Validation_RequiredTestTypeCode(string testTypeCode, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestPeriodOrIntervalValue = 4;
		subject.UnitOfTimePeriodOrIntervalCode = "o8";
		//Test Parameters
		subject.TestTypeCode = testTypeCode;
		//At Least one
		subject.MeasurementValue = 3;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "qQ";
		subject.UnitOfTimePeriodOrIntervalCode = "o8";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		//At Least one
		subject.MeasurementValue = 3;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o8", true)]
	public void Validation_RequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "qQ";
		subject.TestPeriodOrIntervalValue = 4;
		//Test Parameters
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		//At Least one
		subject.MeasurementValue = 3;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(3, "A", true)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "qQ";
		subject.TestPeriodOrIntervalValue = 4;
		subject.UnitOfTimePeriodOrIntervalCode = "o8";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(0, "7", true)]
	public void Validation_AtLeastOneMeasurementValue(decimal measurementValue, string nonNumericTestValue, bool isValidExpected)
	{
		var subject = new ATR_AnimalTestResult();
		//Required fields
		subject.TestTypeCode = "qQ";
		subject.TestPeriodOrIntervalValue = 4;
		subject.UnitOfTimePeriodOrIntervalCode = "o8";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.NonNumericTestValue = nonNumericTestValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
