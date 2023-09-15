using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class MCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCT*zrc*n5*7*2*to*5*Q*rU";

		var expected = new MCT_TariffAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "zrc",
			TariffValueCode = "n5",
			RangeMinimum = 7,
			RangeMaximum = 2,
			RateValueQualifier = "to",
			Rate = 5,
			TariffReferenceFlagCode = "Q",
			SpecialChargeDescription = "rU",
		};

		var actual = Map.MapObject<MCT_TariffAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zrc", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "to";
			subject.Rate = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("to", 5, true)]
	[InlineData("to", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal rate, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "zrc";
		subject.RateValueQualifier = rateValueQualifier;
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
