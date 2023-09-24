using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*N*f3*Z*h*5*1*GH*b*5*9*o";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "N",
			AllowanceOrChargeMethodOfHandlingCode = "f3",
			AllowanceOrChargeNumber = "Z",
			ExceptionNumber = "h",
			AllowanceOrChargeRate = 5,
			AllowanceOrChargeQuantity = 1,
			UnitOrBasisForMeasurementCode = "GH",
			AllowanceOrChargeTotalAmount = "b",
			AllowanceOrChargePercent = 5,
			DollarBasisForPercent = 9,
			OptionNumber = "o",
		};

		var actual = Map.MapObject<G72_AllowanceOrCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "f3";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 1;
			subject.UnitOrBasisForMeasurementCode = "GH";
		}
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 5;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f3", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "N";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 1;
			subject.UnitOrBasisForMeasurementCode = "GH";
		}
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 5;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "GH", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "GH", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "N";
		subject.AllowanceOrChargeMethodOfHandlingCode = "f3";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 5;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 9, true)]
	[InlineData(5, 0, false)]
	[InlineData(0, 9, false)]
	public void Validation_AllAreRequiredAllowanceOrChargePercent(decimal allowanceOrChargePercent, decimal dollarBasisForPercent, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "N";
		subject.AllowanceOrChargeMethodOfHandlingCode = "f3";
		if (allowanceOrChargePercent > 0)
			subject.AllowanceOrChargePercent = allowanceOrChargePercent;
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 1;
			subject.UnitOrBasisForMeasurementCode = "GH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "Z", true)]
	[InlineData("o", "", false)]
	[InlineData("", "Z", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "N";
		subject.AllowanceOrChargeMethodOfHandlingCode = "f3";
		subject.OptionNumber = optionNumber;
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 1;
			subject.UnitOrBasisForMeasurementCode = "GH";
		}
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 5;
			subject.DollarBasisForPercent = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
