using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SWRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWR*Ry*5*3*m*K*V9x";

		var expected = new SWR_SwitchingRates()
		{
			RateValueQualifier = "Ry",
			Rate = 5,
			Rate2 = 3,
			AmountCharged = "m",
			AmountQualifierCode = "K",
			SpecialChargeOrAllowanceCode = "V9x",
		};

		var actual = Map.MapObject<SWR_SwitchingRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ry", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.Rate = 5;
		subject.Rate2 = 3;
		subject.AmountCharged = "m";
		subject.AmountQualifierCode = "K";
		subject.SpecialChargeOrAllowanceCode = "V9x";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "Ry";
		subject.Rate2 = 3;
		subject.AmountCharged = "m";
		subject.AmountQualifierCode = "K";
		subject.SpecialChargeOrAllowanceCode = "V9x";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredRate2(decimal rate2, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "Ry";
		subject.Rate = 5;
		subject.AmountCharged = "m";
		subject.AmountQualifierCode = "K";
		subject.SpecialChargeOrAllowanceCode = "V9x";
		//Test Parameters
		if (rate2 > 0) 
			subject.Rate2 = rate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "Ry";
		subject.Rate = 5;
		subject.Rate2 = 3;
		subject.AmountQualifierCode = "K";
		subject.SpecialChargeOrAllowanceCode = "V9x";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "Ry";
		subject.Rate = 5;
		subject.Rate2 = 3;
		subject.AmountCharged = "m";
		subject.SpecialChargeOrAllowanceCode = "V9x";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V9x", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "Ry";
		subject.Rate = 5;
		subject.Rate2 = 3;
		subject.AmountCharged = "m";
		subject.AmountQualifierCode = "K";
		//Test Parameters
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
