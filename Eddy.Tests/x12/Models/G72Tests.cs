using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*P*mG*Z*1*6*5*sG*4*9*2*9*0";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "P",
			AllowanceOrChargeMethodOfHandlingCode = "mG",
			AllowanceOrChargeNumber = "Z",
			ExceptionNumber = "1",
			AllowanceOrChargeRate = 6,
			AllowanceOrChargeQuantity = 5,
			UnitOrBasisForMeasurementCode = "sG",
			AllowanceOrChargeTotalAmount = "4",
			PercentDecimalFormat = 9,
			DollarBasisForPercent = 2,
			OptionNumber = "9",
			Description = "0",
		};

		var actual = Map.MapObject<G72_AllowanceOrCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "mG";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mG", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "P";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "sG", true)]
	[InlineData(0, "sG", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "P";
		subject.AllowanceOrChargeMethodOfHandlingCode = "mG";
		if (allowanceOrChargeQuantity > 0)
		subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(9, 2, true)]
	[InlineData(0, 2, false)]
	[InlineData(9, 0, false)]
	public void Validation_AllAreRequiredPercentDecimalFormat(decimal percentDecimalFormat, decimal dollarBasisForPercent, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "P";
		subject.AllowanceOrChargeMethodOfHandlingCode = "mG";
		if (percentDecimalFormat > 0)
		subject.PercentDecimalFormat = percentDecimalFormat;
		if (dollarBasisForPercent > 0)
		subject.DollarBasisForPercent = dollarBasisForPercent;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Z", true)]
	[InlineData("9", "", false)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "P";
		subject.AllowanceOrChargeMethodOfHandlingCode = "mG";
		subject.OptionNumber = optionNumber;
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
