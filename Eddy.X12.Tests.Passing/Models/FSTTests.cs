using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FST*2*V*r*nhZ1Bqv8*WX6vcsN7*RB9*r52X*6b*B*3H*qE*Sv*t";

		var expected = new FST_ForecastSchedule()
		{
			Quantity = 2,
			ForecastQualifier = "V",
			TimingQualifier = "r",
			Date = "nhZ1Bqv8",
			Date2 = "WX6vcsN7",
			DateTimeQualifier = "RB9",
			Time = "r52X",
			ReferenceIdentificationQualifier = "6b",
			ReferenceIdentification = "B",
			PlanningScheduleTypeCode = "3H",
			QuantityQualifier = "qE",
			AdjustmentReasonCode = "Sv",
			Description = "t",
		};

		var actual = Map.MapObject<FST_ForecastSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.ForecastQualifier = "V";
		subject.TimingQualifier = "r";
		subject.Date = "nhZ1Bqv8";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredForecastQualifier(string forecastQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 2;
		subject.TimingQualifier = "r";
		subject.Date = "nhZ1Bqv8";
		subject.ForecastQualifier = forecastQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredTimingQualifier(string timingQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 2;
		subject.ForecastQualifier = "V";
		subject.Date = "nhZ1Bqv8";
		subject.TimingQualifier = timingQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nhZ1Bqv8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 2;
		subject.ForecastQualifier = "V";
		subject.TimingQualifier = "r";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("RB9", "r52X", true)]
	[InlineData("", "r52X", false)]
	[InlineData("RB9", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string time, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 2;
		subject.ForecastQualifier = "V";
		subject.TimingQualifier = "r";
		subject.Date = "nhZ1Bqv8";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("6b", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("6b", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 2;
		subject.ForecastQualifier = "V";
		subject.TimingQualifier = "r";
		subject.Date = "nhZ1Bqv8";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Sv", true)]
	[InlineData("t", "", false)]
	public void Validation_ARequiresBDescription(string description, string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 2;
		subject.ForecastQualifier = "V";
		subject.TimingQualifier = "r";
		subject.Date = "nhZ1Bqv8";
		subject.Description = description;
		subject.AdjustmentReasonCode = adjustmentReasonCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
