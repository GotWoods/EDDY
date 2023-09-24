using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class FSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FST*5*s*u*32gCOK*UfavQF*5ow*xXuJ*Ne*v*pb";

		var expected = new FST_ForecastSchedule()
		{
			Quantity = 5,
			ForecastQualifier = "s",
			ForecastTimingQualifier = "u",
			Date = "32gCOK",
			Date2 = "UfavQF",
			DateTimeQualifier = "5ow",
			Time = "xXuJ",
			ReferenceNumberQualifier = "Ne",
			ReferenceNumber = "v",
			PlanningScheduleTypeCode = "pb",
		};

		var actual = Map.MapObject<FST_ForecastSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.ForecastQualifier = "s";
		subject.ForecastTimingQualifier = "u";
		subject.Date = "32gCOK";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "5ow";
			subject.Time = "xXuJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ne";
			subject.ReferenceNumber = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredForecastQualifier(string forecastQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 5;
		subject.ForecastTimingQualifier = "u";
		subject.Date = "32gCOK";
		subject.ForecastQualifier = forecastQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "5ow";
			subject.Time = "xXuJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ne";
			subject.ReferenceNumber = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredForecastTimingQualifier(string forecastTimingQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 5;
		subject.ForecastQualifier = "s";
		subject.Date = "32gCOK";
		subject.ForecastTimingQualifier = forecastTimingQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "5ow";
			subject.Time = "xXuJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ne";
			subject.ReferenceNumber = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("32gCOK", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 5;
		subject.ForecastQualifier = "s";
		subject.ForecastTimingQualifier = "u";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "5ow";
			subject.Time = "xXuJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ne";
			subject.ReferenceNumber = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5ow", "xXuJ", true)]
	[InlineData("5ow", "", false)]
	[InlineData("", "xXuJ", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string time, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 5;
		subject.ForecastQualifier = "s";
		subject.ForecastTimingQualifier = "u";
		subject.Date = "32gCOK";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ne";
			subject.ReferenceNumber = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ne", "v", true)]
	[InlineData("Ne", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 5;
		subject.ForecastQualifier = "s";
		subject.ForecastTimingQualifier = "u";
		subject.Date = "32gCOK";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "5ow";
			subject.Time = "xXuJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
