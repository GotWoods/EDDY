using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L8*9*cq*9*m*h*2*c2*R*Wv2*QW*3";

		var expected = new L8_LineItemSubtotal()
		{
			BilledRatedAsQuantity = 9,
			BilledRatedAsQualifier = "cq",
			Weight = 9,
			WeightUnitCode = "m",
			WeightQualifier = "h",
			FreightRate = 2,
			RateValueQualifier = "c2",
			Amount = "R",
			SpecialChargeOrAllowanceCode = "Wv2",
			SpecialChargeDescription = "QW",
			ChargeMethodOfPaymentCode = "3",
		};

		var actual = Map.MapObject<L8_LineItemSubtotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "cq", true)]
	[InlineData(0, "cq", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (billedRatedAsQuantity > 0)
		subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "c2", true)]
	[InlineData(0, "c2", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "R", true)]
	[InlineData("Wv2", "", false)]
	public void Validation_ARequiresBSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, string amount, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
