using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class FSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FST*7*c*p*aDz3nlkC*5I9YxxuZ*RHo*w5dG*KQ*y*7X*Uc*wB*b";

		var expected = new FST_ForecastSchedule()
		{
			Quantity = 7,
			ForecastQualifier = "c",
			TimingQualifier = "p",
			Date = "aDz3nlkC",
			Date2 = "5I9YxxuZ",
			DateTimeQualifier = "RHo",
			Time = "w5dG",
			ReferenceIdentificationQualifier = "KQ",
			ReferenceIdentification = "y",
			PlanningScheduleTypeCode = "7X",
			QuantityQualifier = "Uc",
			AdjustmentReasonCode = "wB",
			Description = "b",
		};

		var actual = Map.MapObject<FST_ForecastSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.ForecastQualifier = "c";
		subject.TimingQualifier = "p";
		subject.Date = "aDz3nlkC";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "RHo";
			subject.Time = "w5dG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KQ";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredForecastQualifier(string forecastQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 7;
		subject.TimingQualifier = "p";
		subject.Date = "aDz3nlkC";
		subject.ForecastQualifier = forecastQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "RHo";
			subject.Time = "w5dG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KQ";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredTimingQualifier(string timingQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 7;
		subject.ForecastQualifier = "c";
		subject.Date = "aDz3nlkC";
		subject.TimingQualifier = timingQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "RHo";
			subject.Time = "w5dG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KQ";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aDz3nlkC", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 7;
		subject.ForecastQualifier = "c";
		subject.TimingQualifier = "p";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "RHo";
			subject.Time = "w5dG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KQ";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RHo", "w5dG", true)]
	[InlineData("RHo", "", false)]
	[InlineData("", "w5dG", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string time, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 7;
		subject.ForecastQualifier = "c";
		subject.TimingQualifier = "p";
		subject.Date = "aDz3nlkC";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KQ";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KQ", "y", true)]
	[InlineData("KQ", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 7;
		subject.ForecastQualifier = "c";
		subject.TimingQualifier = "p";
		subject.Date = "aDz3nlkC";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "RHo";
			subject.Time = "w5dG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "wB", true)]
	[InlineData("b", "", false)]
	[InlineData("", "wB", true)]
	public void Validation_ARequiresBDescription(string description, string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 7;
		subject.ForecastQualifier = "c";
		subject.TimingQualifier = "p";
		subject.Date = "aDz3nlkC";
		subject.Description = description;
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "RHo";
			subject.Time = "w5dG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KQ";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
