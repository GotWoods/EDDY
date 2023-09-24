using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCT*TDF*uG*9*1*8C*5*K*TH";

		var expected = new MCT_TariffAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "TDF",
			TariffValueCode = "uG",
			RangeMinimum = 9,
			RangeMaximum = 1,
			RateValueQualifier = "8C",
			Rate = 5,
			TariffReferenceFlag = "K",
			SpecialChargeDescription = "TH",
		};

		var actual = Map.MapObject<MCT_TariffAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TDF", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "8C";
			subject.Rate = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("8C", 5, true)]
	[InlineData("8C", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal rate, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "TDF";
		subject.RateValueQualifier = rateValueQualifier;
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
