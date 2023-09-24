using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*n*EE*Z*o*4*4*bm*7*2*9*W";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "n",
			AllowanceOrChargeMethodOfHandlingCode = "EE",
			AllowanceOrChargeNumber = "Z",
			ExceptionNumber = "o",
			AllowanceOrChargeRate = 4,
			AllowanceOrChargeQuantity = 4,
			UnitOrBasisForMeasurementCode = "bm",
			AllowanceOrChargeTotalAmount = "7",
			Percent = 2,
			DollarBasisForPercent = 9,
			OptionNumber = "W",
		};

		var actual = Map.MapObject<G72_AllowanceOrCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "EE";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "bm";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EE", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "bm";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "bm", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "bm", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = "EE";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 9, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 9, false)]
	public void Validation_AllAreRequiredPercent(decimal percent, decimal dollarBasisForPercent, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = "EE";
		if (percent > 0)
			subject.Percent = percent;
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "bm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "Z", true)]
	[InlineData("W", "", false)]
	[InlineData("", "Z", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = "EE";
		subject.OptionNumber = optionNumber;
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "bm";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
