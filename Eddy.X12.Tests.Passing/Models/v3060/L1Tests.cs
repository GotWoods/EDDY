using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*7*5*EM*J*s*S*Vfj*ZhB*Y*F*B*pu*P*GF*Mn*P*8*xy*1*Qci";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 7,
			FreightRate = 5,
			RateValueQualifier = "EM",
			Charge = "J",
			Advances = "s",
			PrepaidAmount = "S",
			RateCombinationPointCode = "Vfj",
			SpecialChargeOrAllowanceCode = "ZhB",
			RateClassCode = "Y",
			EntitlementCode = "F",
			ChargeMethodOfPayment = "B",
			SpecialChargeDescription = "pu",
			TariffApplicationCode = "P",
			DeclaredValue = "GF",
			RateValueQualifier2 = "Mn",
			LadingLiabilityCode = "P",
			BilledRatedAsQuantity = 8,
			BilledRatedAsQualifier = "xy",
			Percent = 1,
			CurrencyCode = "Qci",
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GF", "Mn", true)]
	[InlineData("GF", "", false)]
	[InlineData("", "Mn", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 8;
			subject.BilledRatedAsQualifier = "xy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "xy", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "xy", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L1_RateAndCharges();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "GF";
			subject.RateValueQualifier2 = "Mn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
