using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*3*6*kn*o*n*L*fC0*L5Q*G*2*g*NG*X*sm*Qw*s*3*OT*4*WJ3*J*84";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 3,
			FreightRate = 6,
			RateValueQualifier = "kn",
			AmountCharged = "o",
			Advances = "n",
			PrepaidAmount = "L",
			RateCombinationPointCode = "fC0",
			SpecialChargeOrAllowanceCode = "L5Q",
			RateClassCode = "G",
			EntitlementCode = "2",
			ChargeMethodOfPayment = "g",
			SpecialChargeDescription = "NG",
			TariffApplicationCode = "X",
			DeclaredValue = "sm",
			RateValueQualifier2 = "Qw",
			LadingLiabilityCode = "s",
			BilledRatedAsQuantity = 3,
			BilledRatedAsQualifier = "OT",
			PercentageAsDecimal = 4,
			CurrencyCode = "WJ3",
			Amount = "J",
			LadingValue = 84,
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "kn", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "kn", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "sm";
			subject.RateValueQualifier2 = "Qw";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "OT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sm", "Qw", true)]
	[InlineData("sm", "", false)]
	[InlineData("", "Qw", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "kn";
		}
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "OT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "OT", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "OT", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "kn";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "sm";
			subject.RateValueQualifier2 = "Qw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
