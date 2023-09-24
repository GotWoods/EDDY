using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class L8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L8*7*xx*5*V*t*9*5t*G*Nic*Mz*V";

		var expected = new L8_LineItemSubtotal()
		{
			BilledRatedAsQuantity = 7,
			BilledRatedAsQualifier = "xx",
			Weight = 5,
			WeightUnitCode = "V",
			WeightQualifier = "t",
			FreightRate = 9,
			RateValueQualifier = "5t",
			Amount = "G",
			SpecialChargeOrAllowanceCode = "Nic",
			SpecialChargeDescription = "Mz",
			ChargeMethodOfPaymentCode = "V",
		};

		var actual = Map.MapObject<L8_LineItemSubtotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "xx", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "xx", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "5t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "5t", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "5t", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 7;
			subject.BilledRatedAsQualifier = "xx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Nic", "G", true)]
	[InlineData("Nic", "", false)]
	[InlineData("", "G", true)]
	public void Validation_ARequiresBSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, string amount, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 7;
			subject.BilledRatedAsQualifier = "xx";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "5t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
