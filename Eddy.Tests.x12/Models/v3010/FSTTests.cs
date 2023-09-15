using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class FSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FST*1*k*v*7lj73n*ZwgltH*0zx*AbBw*4p*w";

		var expected = new FST_ForecastSchedule()
		{
			Quantity = 1,
			ForecastQualifier = "k",
			ForecastTimingQualifier = "v",
			Date = "7lj73n",
			Date2 = "ZwgltH",
			DateTimeQualifier = "0zx",
			Time = "AbBw",
			ReferenceNumberQualifier = "4p",
			ReferenceNumber = "w",
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
		subject.ForecastQualifier = "k";
		subject.ForecastTimingQualifier = "v";
		subject.Date = "7lj73n";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredForecastQualifier(string forecastQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastTimingQualifier = "v";
		subject.Date = "7lj73n";
		subject.ForecastQualifier = forecastQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredForecastTimingQualifier(string forecastTimingQualifier, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastQualifier = "k";
		subject.Date = "7lj73n";
		subject.ForecastTimingQualifier = forecastTimingQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7lj73n", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new FST_ForecastSchedule();
		subject.Quantity = 1;
		subject.ForecastQualifier = "k";
		subject.ForecastTimingQualifier = "v";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
