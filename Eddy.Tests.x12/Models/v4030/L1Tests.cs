using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*2*2*Bi*j*Y*L*B5E*6CH*8*s*t*PT*2*xT*tk*b*4*Z8*7*zd1*e*41";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 2,
			FreightRate = 2,
			RateValueQualifier = "Bi",
			Charge = "j",
			Advances = "Y",
			PrepaidAmount = "L",
			RateCombinationPointCode = "B5E",
			SpecialChargeOrAllowanceCode = "6CH",
			RateClassCode = "8",
			EntitlementCode = "s",
			ChargeMethodOfPayment = "t",
			SpecialChargeDescription = "PT",
			TariffApplicationCode = "2",
			DeclaredValue = "xT",
			RateValueQualifier2 = "tk",
			LadingLiabilityCode = "b",
			BilledRatedAsQuantity = 4,
			BilledRatedAsQualifier = "Z8",
			Percent = 7,
			CurrencyCode = "zd1",
			Amount = "e",
			LadingValue = 41,
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Bi", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Bi", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "xT";
			subject.RateValueQualifier2 = "tk";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 4;
			subject.BilledRatedAsQualifier = "Z8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xT", "tk", true)]
	[InlineData("xT", "", false)]
	[InlineData("", "tk", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 2;
			subject.RateValueQualifier = "Bi";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 4;
			subject.BilledRatedAsQualifier = "Z8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Z8", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Z8", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 2;
			subject.RateValueQualifier = "Bi";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "xT";
			subject.RateValueQualifier2 = "tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
