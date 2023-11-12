using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.Tests.Models.v7040;

public class SWRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWR*2D*4*8*V*c*du3*qV*4";

		var expected = new SWR_SwitchingRates()
		{
			RateValueQualifier = "2D",
			Rate = 4,
			Rate2 = 8,
			AmountCharged = "V",
			AmountQualifierCode = "c",
			SpecialChargeOrAllowanceCode = "du3",
			RateValueQualifier2 = "qV",
			AmountCharged2 = "4",
		};

		var actual = Map.MapObject<SWR_SwitchingRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2D", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.Rate = 4;
		subject.Rate2 = 8;
		subject.AmountCharged = "V";
		subject.AmountQualifierCode = "c";
		subject.SpecialChargeOrAllowanceCode = "du3";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "2D";
		subject.Rate2 = 8;
		subject.AmountCharged = "V";
		subject.AmountQualifierCode = "c";
		subject.SpecialChargeOrAllowanceCode = "du3";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredRate2(decimal rate2, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "2D";
		subject.Rate = 4;
		subject.AmountCharged = "V";
		subject.AmountQualifierCode = "c";
		subject.SpecialChargeOrAllowanceCode = "du3";
		//Test Parameters
		if (rate2 > 0) 
			subject.Rate2 = rate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "2D";
		subject.Rate = 4;
		subject.Rate2 = 8;
		subject.AmountQualifierCode = "c";
		subject.SpecialChargeOrAllowanceCode = "du3";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "2D";
		subject.Rate = 4;
		subject.Rate2 = 8;
		subject.AmountCharged = "V";
		subject.SpecialChargeOrAllowanceCode = "du3";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("du3", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new SWR_SwitchingRates();
		//Required fields
		subject.RateValueQualifier = "2D";
		subject.Rate = 4;
		subject.Rate2 = 8;
		subject.AmountCharged = "V";
		subject.AmountQualifierCode = "c";
		//Test Parameters
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
