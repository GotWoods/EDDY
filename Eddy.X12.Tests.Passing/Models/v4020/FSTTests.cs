using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class FSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FST*6*o*3*MOpKc9lI*JPnoAw0D*klq*OsBj*vB*Z*Tu";

		var expected = new FST_ForecastSchedule()
		{
			Quantity = 6,
			ForecastQualifier = "o",
			TimingQualifier = "3",
			Date = "MOpKc9lI",
			Date2 = "JPnoAw0D",
			DateTimeQualifier = "klq",
			Time = "OsBj",
			ReferenceIdentificationQualifier = "vB",
			ReferenceIdentification = "Z",
			PlanningScheduleTypeCode = "Tu",
		};

		var actual = Map.MapObject<FST_ForecastSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.ForecastQualifier = "o";
		subject.TimingQualifier = "3";
		subject.Date = "MOpKc9lI";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "klq";
			subject.Time = "OsBj";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "vB";
			subject.ReferenceIdentification = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredForecastQualifier(string forecastQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 6;
		subject.TimingQualifier = "3";
		subject.Date = "MOpKc9lI";
		subject.ForecastQualifier = forecastQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "klq";
			subject.Time = "OsBj";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "vB";
			subject.ReferenceIdentification = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredTimingQualifier(string timingQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 6;
		subject.ForecastQualifier = "o";
		subject.Date = "MOpKc9lI";
		subject.TimingQualifier = timingQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "klq";
			subject.Time = "OsBj";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "vB";
			subject.ReferenceIdentification = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MOpKc9lI", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 6;
		subject.ForecastQualifier = "o";
		subject.TimingQualifier = "3";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "klq";
			subject.Time = "OsBj";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "vB";
			subject.ReferenceIdentification = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("klq", "OsBj", true)]
	[InlineData("klq", "", false)]
	[InlineData("", "OsBj", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string time, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 6;
		subject.ForecastQualifier = "o";
		subject.TimingQualifier = "3";
		subject.Date = "MOpKc9lI";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "vB";
			subject.ReferenceIdentification = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vB", "Z", true)]
	[InlineData("vB", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 6;
		subject.ForecastQualifier = "o";
		subject.TimingQualifier = "3";
		subject.Date = "MOpKc9lI";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "klq";
			subject.Time = "OsBj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
