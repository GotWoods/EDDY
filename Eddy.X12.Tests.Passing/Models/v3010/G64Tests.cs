using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G64Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G64*P*9*6*z*sFS";

		var expected = new G64_TotalTimePeriodsAndCharges()
		{
			TimePeriodQualifier = "P",
			NumberOfPeriods = 9,
			Rate = 6,
			Charge = "z",
			SpecialChargeCode = "sFS",
		};

		var actual = Map.MapObject<G64_TotalTimePeriodsAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.NumberOfPeriods = 9;
		subject.Rate = 6;
		subject.Charge = "z";
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.TimePeriodQualifier = "P";
		subject.Rate = 6;
		subject.Charge = "z";
		if (numberOfPeriods > 0)
			subject.NumberOfPeriods = numberOfPeriods;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.TimePeriodQualifier = "P";
		subject.NumberOfPeriods = 9;
		subject.Charge = "z";
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new G64_TotalTimePeriodsAndCharges();
		subject.TimePeriodQualifier = "P";
		subject.NumberOfPeriods = 9;
		subject.Rate = 6;
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
