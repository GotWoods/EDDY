using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class SWRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWR*zB*2*7*w*0*2jr";

		var expected = new SWR_SwitchingRates()
		{
			RateValueQualifier = "zB",
			Rate = 2,
			Rate2 = 7,
			AmountCharged = "w",
			AmountQualifierCode = "0",
			SpecialChargeOrAllowanceCode = "2jr",
		};

		var actual = Map.MapObject<SWR_SwitchingRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zB", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.Rate = 2;
		subject.Rate2 = 7;
		subject.AmountCharged = "w";
		subject.AmountQualifierCode = "0";
		subject.SpecialChargeOrAllowanceCode = "2jr";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "zB";
		subject.Rate2 = 7;
		subject.AmountCharged = "w";
		subject.AmountQualifierCode = "0";
		subject.SpecialChargeOrAllowanceCode = "2jr";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredRate2(decimal rate2, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "zB";
		subject.Rate = 2;
		subject.AmountCharged = "w";
		subject.AmountQualifierCode = "0";
		subject.SpecialChargeOrAllowanceCode = "2jr";
		//Test Parameters
		if (rate2 > 0) 
			subject.Rate2 = rate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "zB";
		subject.Rate = 2;
		subject.Rate2 = 7;
		subject.AmountQualifierCode = "0";
		subject.SpecialChargeOrAllowanceCode = "2jr";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "zB";
		subject.Rate = 2;
		subject.Rate2 = 7;
		subject.AmountCharged = "w";
		subject.SpecialChargeOrAllowanceCode = "2jr";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2jr", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "zB";
		subject.Rate = 2;
		subject.Rate2 = 7;
		subject.AmountCharged = "w";
		subject.AmountQualifierCode = "0";
		//Test Parameters
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
