using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*5*1*5m*D*p*E*vTz*pCC*X*A*R*If*w*dv*gc*K*1*EG*6";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 5,
			FreightRate = 1,
			RateValueQualifier = "5m",
			Charge = "D",
			Advances = "p",
			PrepaidAmount = "E",
			RateCombinationPointCode = "vTz",
			SpecialChargeOrAllowanceCode = "pCC",
			RateClassCode = "X",
			EntitlementCode = "A",
			ChargeMethodOfPayment = "R",
			SpecialChargeDescription = "If",
			TariffApplicationCode = "w",
			DeclaredValue = "dv",
			RateValueQualifier2 = "gc",
			LadingLiabilityCode = "K",
			BilledRatedAsQuantity = 1,
			BilledRatedAsQualifier = "EG",
			Percent = 6,
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dv", "gc", true)]
	[InlineData("dv", "", false)]
	[InlineData("", "gc", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "EG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "EG", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "EG", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "dv";
			subject.RateValueQualifier2 = "gc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
