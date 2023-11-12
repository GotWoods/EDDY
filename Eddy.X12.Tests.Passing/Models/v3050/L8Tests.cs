using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class L8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L8*1*Oe*3*E*Z*4*HV*S*clL*R2*j";

		var expected = new L8_LineItemSubtotal()
		{
			BilledRatedAsQuantity = 1,
			BilledRatedAsQualifier = "Oe",
			Weight = 3,
			WeightUnitCode = "E",
			WeightQualifier = "Z",
			FreightRate = 4,
			RateValueQualifier = "HV",
			Amount = "S",
			SpecialChargeOrAllowanceCode = "clL",
			SpecialChargeDescription = "R2",
			ChargeMethodOfPayment = "j",
		};

		var actual = Map.MapObject<L8_LineItemSubtotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Oe", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Oe", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 4;
			subject.RateValueQualifier = "HV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "HV", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "HV", false)]
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
			subject.BilledRatedAsQualifier = "Oe";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("clL", "S", true)]
	[InlineData("clL", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, string amount, bool isValidExpected)
	{
		var subject = new L8_LineItemSubtotal();
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "Oe";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 4;
			subject.RateValueQualifier = "HV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
