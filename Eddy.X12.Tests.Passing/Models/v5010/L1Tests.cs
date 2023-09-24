using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*8*1*CX*Y*b*8*jz1*brQ*0*q*6*Fe*7*Za*IS*O*3*yF*2*R1S*I*29";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 8,
			FreightRate = 1,
			RateValueQualifier = "CX",
			AmountCharged = "Y",
			Advances = "b",
			PrepaidAmount = "8",
			RateCombinationPointCode = "jz1",
			SpecialChargeOrAllowanceCode = "brQ",
			RateClassCode = "0",
			EntitlementCode = "q",
			ChargeMethodOfPayment = "6",
			SpecialChargeDescription = "Fe",
			TariffApplicationCode = "7",
			DeclaredValue = "Za",
			RateValueQualifier2 = "IS",
			LadingLiabilityCode = "O",
			BilledRatedAsQuantity = 3,
			BilledRatedAsQualifier = "yF",
			PercentageAsDecimal = 2,
			CurrencyCode = "R1S",
			Amount = "I",
			LadingValue = 29,
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "CX", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "CX", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "Za";
			subject.RateValueQualifier2 = "IS";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "yF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Za", "IS", true)]
	[InlineData("Za", "", false)]
	[InlineData("", "IS", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "CX";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "yF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "yF", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "yF", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "CX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "Za";
			subject.RateValueQualifier2 = "IS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
