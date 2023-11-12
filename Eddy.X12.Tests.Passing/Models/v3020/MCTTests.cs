using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class MCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCT*Qba*j8*3*6*Wx*4*q*JZ";

		var expected = new MCT_TariffAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "Qba",
			TariffValueCode = "j8",
			RangeMinimum = 3,
			RangeMaximum = 6,
			RateValueQualifier = "Wx",
			SpecialCharge = 4,
			TariffReferenceFlag = "q",
			SpecialChargeDescription = "JZ",
		};

		var actual = Map.MapObject<MCT_TariffAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qba", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.SpecialCharge > 0)
		{
			subject.RateValueQualifier = "Wx";
			subject.SpecialCharge = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Wx", 4, true)]
	[InlineData("Wx", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal specialCharge, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "Qba";
		subject.RateValueQualifier = rateValueQualifier;
		if (specialCharge > 0)
			subject.SpecialCharge = specialCharge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
