using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class L8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L8*1*HY*4*S*S*5*l3*F*J1q*7c*v";

		var expected = new L8_LineItemSubtotal()
		{
			BilledRatedAsQuantity = 1,
			BilledRatedAsQualifier = "HY",
			Weight = 4,
			WeightUnitCode = "S",
			WeightQualifier = "S",
			FreightRate = 5,
			RateValueQualifier = "l3",
			Amount = "F",
			SpecialChargeOrAllowanceCode = "J1q",
			SpecialChargeDescription = "7c",
			ChargeMethodOfPayment = "v",
		};

		var actual = Map.MapObject<L8_LineItemSubtotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "HY", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "HY", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 5;
			subject.RateValueQualifier = "l3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "l3", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "l3", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "HY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J1q", "F", true)]
	[InlineData("J1q", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, string amount, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "HY";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 5;
			subject.RateValueQualifier = "l3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
