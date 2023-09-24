using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G64Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G64*A*1*7*s*WjB";

		var expected = new G64_TotalTimePeriodsAndCharges()
		{
			TimePeriodQualifier = "A",
			NumberOfPeriods = 1,
			Rate = 7,
			Charge = "s",
			SpecialChargeOrAllowanceCode = "WjB",
		};

		var actual = Map.MapObject<G64_TotalTimePeriodsAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.NumberOfPeriods = 1;
		subject.Rate = 7;
		subject.Charge = "s";
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.TimePeriodQualifier = "A";
		subject.Rate = 7;
		subject.Charge = "s";
		if (numberOfPeriods > 0)
			subject.NumberOfPeriods = numberOfPeriods;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.TimePeriodQualifier = "A";
		subject.NumberOfPeriods = 1;
		subject.Charge = "s";
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.TimePeriodQualifier = "A";
		subject.NumberOfPeriods = 1;
		subject.Rate = 7;
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
