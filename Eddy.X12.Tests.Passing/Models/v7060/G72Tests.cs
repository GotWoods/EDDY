using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*U*vS*x*2*2*9*H4*U*2*8*t*0";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "U",
			AllowanceOrChargeMethodOfHandlingCode = "vS",
			AllowanceOrChargeNumber = "x",
			ExceptionNumber = "2",
			AllowanceOrChargeRate = 2,
			AllowanceOrChargeQuantity = 9,
			UnitOrBasisForMeasurementCode = "H4",
			AllowanceOrChargeTotalAmount = "U",
			PercentDecimalFormat = 2,
			DollarBasisForPercent = 8,
			OptionNumber = "t",
			Description = "0",
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
		subject.AllowanceOrChargeMethodOfHandlingCode = "vS";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "H4";
		}
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 2;
			subject.DollarBasisForPercent = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vS", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "H4";
		}
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 2;
			subject.DollarBasisForPercent = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "H4", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "H4", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = "vS";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 2;
			subject.DollarBasisForPercent = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 8, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 8, false)]
	public void Validation_AllAreRequiredPercentDecimalFormat(decimal percentDecimalFormat, decimal dollarBasisForPercent, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = "vS";
		if (percentDecimalFormat > 0)
			subject.PercentDecimalFormat = percentDecimalFormat;
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "H4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "x", true)]
	[InlineData("t", "", false)]
	[InlineData("", "x", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "U";
		subject.AllowanceOrChargeMethodOfHandlingCode = "vS";
		subject.OptionNumber = optionNumber;
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "H4";
		}
		//If one is filled, all are required
		if(subject.PercentDecimalFormat > 0 || subject.PercentDecimalFormat > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.PercentDecimalFormat = 2;
			subject.DollarBasisForPercent = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
