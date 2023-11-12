using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*y*rA*U*W*7*2*LT*D*2*2*1";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "y",
			AllowanceOrChargeMethodOfHandlingCode = "rA",
			AllowanceOrChargeNumber = "U",
			ExceptionNumber = "W",
			AllowanceOrChargeRate = 7,
			AllowanceOrChargeQuantity = 2,
			UnitOrBasisForMeasurementCode = "LT",
			AllowanceOrChargeTotalAmount = "D",
			Percent = 2,
			DollarBasisForPercent = 2,
			OptionNumber = "1",
		};

		var actual = Map.MapObject<G72_AllowanceOrCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "rA";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 2;
			subject.UnitOrBasisForMeasurementCode = "LT";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rA", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 2;
			subject.UnitOrBasisForMeasurementCode = "LT";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "LT", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "LT", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "rA";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 2, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 2, false)]
	public void Validation_AllAreRequiredPercent(decimal percent, decimal dollarBasisForPercent, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "rA";
		if (percent > 0)
			subject.Percent = percent;
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 2;
			subject.UnitOrBasisForMeasurementCode = "LT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "U", true)]
	[InlineData("1", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "rA";
		subject.OptionNumber = optionNumber;
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeQuantity > 0 || subject.AllowanceOrChargeQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeQuantity = 2;
			subject.UnitOrBasisForMeasurementCode = "LT";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || subject.DollarBasisForPercent > 0)
		{
			subject.Percent = 2;
			subject.DollarBasisForPercent = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
