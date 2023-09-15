using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*2*oE*3*d*3*5*Mr*0*8*7*z";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "2",
			AllowanceOrChargeMethodOfHandlingCode = "oE",
			AllowanceOrChargeNumber = "3",
			ExceptionNumber = "d",
			AllowanceOrChargeRate = 3,
			AllowanceOrChargeQuantity = 5,
			UnitOfMeasurementCode = "Mr",
			AllowanceOrChargeTotalAmount = "0",
			AllowanceOrChargePercent = 8,
			DollarBasisForPercent = 7,
			OptionNumber = "z",
		};

		var actual = Map.MapObject<G72_AllowanceOrCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "oE";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOfMeasurementCode = "Mr";
		}
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 8;
			subject.DollarBasisForPercent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oE", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "2";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOfMeasurementCode = "Mr";
		}
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 8;
			subject.DollarBasisForPercent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Mr", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Mr", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "2";
		subject.AllowanceOrChargeMethodOfHandlingCode = "oE";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 8;
			subject.DollarBasisForPercent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 7, true)]
	[InlineData(8, 0, false)]
	[InlineData(0, 7, false)]
	public void Validation_AllAreRequiredAllowanceOrChargePercent(decimal allowanceOrChargePercent, decimal dollarBasisForPercent, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "2";
		subject.AllowanceOrChargeMethodOfHandlingCode = "oE";
		if (allowanceOrChargePercent > 0)
			subject.AllowanceOrChargePercent = allowanceOrChargePercent;
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOfMeasurementCode = "Mr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "3", true)]
	[InlineData("z", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "2";
		subject.AllowanceOrChargeMethodOfHandlingCode = "oE";
		subject.OptionNumber = optionNumber;
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 5;
			subject.UnitOfMeasurementCode = "Mr";
		}
		//If one is filled, all are required
		if(subject.AllowanceOrChargePercent > 0 || subject.AllowanceOrChargePercent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.AllowanceOrChargePercent = 8;
			subject.DollarBasisForPercent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
