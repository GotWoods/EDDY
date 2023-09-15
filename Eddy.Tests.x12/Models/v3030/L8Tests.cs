using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class L8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L8*6*VF*8*y*U*9*sF*i*E56*NQ*Y";

		var expected = new L8_LineItemSubtotal()
		{
			BilledRatedAsQuantity = 6,
			BilledRatedAsQualifier = "VF",
			Weight = 8,
			WeightUnitCode = "y",
			WeightQualifier = "U",
			FreightRate = 9,
			RateValueQualifier = "sF",
			Charge = "i",
			SpecialChargeOrAllowanceCode = "E56",
			SpecialChargeDescription = "NQ",
			ChargeMethodOfPayment = "Y",
		};

		var actual = Map.MapObject<L8_LineItemSubtotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "VF", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "VF", false)]
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
			subject.RateValueQualifier = "sF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "sF", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "sF", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 6;
			subject.BilledRatedAsQualifier = "VF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E56", "i", true)]
	[InlineData("E56", "", false)]
	[InlineData("", "i", true)]
	public void Validation_ARequiresBSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, string charge, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		subject.Charge = charge;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 6;
			subject.BilledRatedAsQualifier = "VF";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "sF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
