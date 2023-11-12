using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*U*SN*r*Q*6*5*7Q*c*7*3*v";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "U",
			AllowanceOrChargeMethodOfHandlingCode = "SN",
			AllowanceOrChargeNumber = "r",
			ExceptionNumber = "Q",
			AllowanceOrChargeRate = 6,
			AllowanceOrChargeQuantity = 5,
			UnitOrBasisForMeasurementCode = "7Q",
			AllowanceOrChargeTotalAmount = "c",
			PercentDecimalFormat = 7,
			DollarBasisForPercent = 3,
			OptionNumber = "v",
		};

		var actual = Map.MapObject<G72_AllowanceOrCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "SN";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOrBasisForMeasurementCode = "7Q";
		}
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 7;
			subject.DollarBasisForPercent = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SN", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOrBasisForMeasurementCode = "7Q";
		}
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 7;
			subject.DollarBasisForPercent = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "7Q", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "7Q", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SN";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 7;
			subject.DollarBasisForPercent = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(7, 3, true)]
	[InlineData(7, 0, false)]
	[InlineData(0, 3, false)]
	public void Validation_AllAreRequiredPercentDecimalFormat(decimal percentDecimalFormat, decimal dollarBasisForPercent, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SN";
		if (percentDecimalFormat > 0)
			subject.PercentDecimalFormat = percentDecimalFormat;
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOrBasisForMeasurementCode = "7Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "r", true)]
	[InlineData("v", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SN";
		subject.OptionNumber = optionNumber;
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOrBasisForMeasurementCode = "7Q";
		}
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 7;
			subject.DollarBasisForPercent = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
