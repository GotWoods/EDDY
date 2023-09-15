using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*1*5*gU*c*o*6*onD*x46*O*v*h*n1*c*8M*M1*R*5*X9";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 1,
			FreightRate = 5,
			RateValueQualifier = "gU",
			Charge = "c",
			Advances = "o",
			PrepaidAmount = "6",
			RateCombinationPointCode = "onD",
			SpecialChargeOrAllowanceCode = "x46",
			RateClassCode = "O",
			EntitlementCode = "v",
			ChargeMethodOfPayment = "h",
			SpecialChargeDescription = "n1",
			TariffApplicationCode = "c",
			DeclaredValue = "8M",
			RateValueQualifier2 = "M1",
			LadingLiabilityCode = "R",
			BilledRatedAsQuantity = 5,
			BilledRatedAsQualifier = "X9",
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8M", "M1", true)]
	[InlineData("8M", "", false)]
	[InlineData("", "M1", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 5;
			subject.BilledRatedAsQualifier = "X9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "X9", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "X9", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "8M";
			subject.RateValueQualifier2 = "M1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
