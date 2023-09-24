using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*8*4*Aj*7*O*6*WbL*ku8*x*S*V*jU*a*B9*2Z*A*2*Hw*6*Kij*h*36";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 8,
			FreightRate = 4,
			RateValueQualifier = "Aj",
			AmountCharged = "7",
			Advances = "O",
			PrepaidAmount = "6",
			RateCombinationPointCode = "WbL",
			SpecialChargeOrAllowanceCode = "ku8",
			RateClassCode = "x",
			EntitlementCode = "S",
			ChargeMethodOfPayment = "V",
			SpecialChargeDescription = "jU",
			TariffApplicationCode = "a",
			DeclaredValue = "B9",
			RateValueQualifier2 = "2Z",
			LadingLiabilityCode = "A",
			BilledRatedAsQuantity = 2,
			BilledRatedAsQualifier = "Hw",
			PercentageAsDecimal = 6,
			CurrencyCode = "Kij",
			Amount = "h",
			LadingValue = 36,
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Aj", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Aj", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "B9";
			subject.RateValueQualifier2 = "2Z";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 2;
			subject.BilledRatedAsQualifier = "Hw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B9", "2Z", true)]
	[InlineData("B9", "", false)]
	[InlineData("", "2Z", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 4;
			subject.RateValueQualifier = "Aj";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 2;
			subject.BilledRatedAsQualifier = "Hw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Hw", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Hw", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 4;
			subject.RateValueQualifier = "Aj";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "B9";
			subject.RateValueQualifier2 = "2Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
