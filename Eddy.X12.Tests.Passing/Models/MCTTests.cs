using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCT*kWO*2i*2*6*kc*7*l*O9";

		var expected = new MCT_TariffAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "kWO",
			TariffValueCode = "2i",
			RangeMinimum = 2,
			RangeMaximum = 6,
			RateValueQualifier = "kc",
			Rate = 7,
			TariffReferenceFlagCode = "l",
			SpecialChargeDescription = "O9",
		};

		var actual = Map.MapObject<MCT_TariffAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kWO", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("kc", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("kc", 0, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal rate, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "kWO";
		subject.RateValueQualifier = rateValueQualifier;
		if (rate > 0)
		subject.Rate = rate;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
