using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SWRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWR*2S*9*2*1*A*xhL*mq*G";

		var expected = new SWR_SwitchingRates()
		{
			RateValueQualifier = "2S",
			Rate = 9,
			Rate2 = 2,
			AmountCharged = "1",
			AmountQualifierCode = "A",
			SpecialChargeOrAllowanceCode = "xhL",
			RateValueQualifier2 = "mq",
			AmountCharged2 = "G",
		};

		var actual = Map.MapObject<SWR_SwitchingRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2S", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		subject.Rate = 9;
		subject.Rate2 = 2;
		subject.AmountCharged = "1";
		subject.AmountQualifierCode = "A";
		subject.SpecialChargeOrAllowanceCode = "xhL";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		subject.RateValueQualifier = "2S";
		subject.Rate2 = 2;
		subject.AmountCharged = "1";
		subject.AmountQualifierCode = "A";
		subject.SpecialChargeOrAllowanceCode = "xhL";
		if (rate > 0)
		subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredRate2(decimal rate2, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		subject.RateValueQualifier = "2S";
		subject.Rate = 9;
		subject.AmountCharged = "1";
		subject.AmountQualifierCode = "A";
		subject.SpecialChargeOrAllowanceCode = "xhL";
		if (rate2 > 0)
		subject.Rate2 = rate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		subject.RateValueQualifier = "2S";
		subject.Rate = 9;
		subject.Rate2 = 2;
		subject.AmountQualifierCode = "A";
		subject.SpecialChargeOrAllowanceCode = "xhL";
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		subject.RateValueQualifier = "2S";
		subject.Rate = 9;
		subject.Rate2 = 2;
		subject.AmountCharged = "1";
		subject.SpecialChargeOrAllowanceCode = "xhL";
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xhL", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		subject.RateValueQualifier = "2S";
		subject.Rate = 9;
		subject.Rate2 = 2;
		subject.AmountCharged = "1";
		subject.AmountQualifierCode = "A";
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
