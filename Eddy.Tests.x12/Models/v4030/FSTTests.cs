using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class FSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FST*1*U*6*MMEFwsIA*f284FCsL*94u*5bnB*pL*H*Ix*5q*ot*6";

		var expected = new FST_ForecastSchedule()
		{
			Quantity = 1,
			ForecastQualifier = "U",
			TimingQualifier = "6",
			Date = "MMEFwsIA",
			Date2 = "f284FCsL",
			DateTimeQualifier = "94u",
			Time = "5bnB",
			ReferenceIdentificationQualifier = "pL",
			ReferenceIdentification = "H",
			PlanningScheduleTypeCode = "Ix",
			QuantityQualifier = "5q",
			AdjustmentReasonCode = "ot",
			Description = "6",
		};

		var actual = Map.MapObject<FST_ForecastSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.ForecastQualifier = "U";
		subject.TimingQualifier = "6";
		subject.Date = "MMEFwsIA";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "94u";
			subject.Time = "5bnB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pL";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredForecastQualifier(string forecastQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.TimingQualifier = "6";
		subject.Date = "MMEFwsIA";
		subject.ForecastQualifier = forecastQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "94u";
			subject.Time = "5bnB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pL";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredTimingQualifier(string timingQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastQualifier = "U";
		subject.Date = "MMEFwsIA";
		subject.TimingQualifier = timingQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "94u";
			subject.Time = "5bnB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pL";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MMEFwsIA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastQualifier = "U";
		subject.TimingQualifier = "6";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "94u";
			subject.Time = "5bnB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pL";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("94u", "5bnB", true)]
	[InlineData("94u", "", false)]
	[InlineData("", "5bnB", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string time, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastQualifier = "U";
		subject.TimingQualifier = "6";
		subject.Date = "MMEFwsIA";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pL";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pL", "H", true)]
	[InlineData("pL", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastQualifier = "U";
		subject.TimingQualifier = "6";
		subject.Date = "MMEFwsIA";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "94u";
			subject.Time = "5bnB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "ot", true)]
	[InlineData("6", "", false)]
	[InlineData("", "ot", true)]
	public void Validation_ARequiresBDescription(string description, string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastQualifier = "U";
		subject.TimingQualifier = "6";
		subject.Date = "MMEFwsIA";
		subject.Description = description;
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "94u";
			subject.Time = "5bnB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pL";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
