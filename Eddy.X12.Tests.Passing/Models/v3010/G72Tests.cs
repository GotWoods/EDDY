using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G72Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G72*I*Wd*x*u*1*8*FH*P*3*6*B";

		var expected = new G72_AllowanceOrCharge()
		{
			AllowanceOrChargeCode = "I",
			AllowanceOrChargeMethodOfHandlingCode = "Wd",
			AllowanceOrChargeNumber = "x",
			ExceptionNumber = "u",
			AllowanceOrChargeRate = 1,
			AllowanceOrChargeQuantity = 8,
			UnitOfMeasurementCode = "FH",
			AllowanceOrChargeTotalAmount = "P",
			AllowanceOrChargePercent = 3,
			DollarBasisForPercent = 6,
			OptionNumber = "B",
		};

		var actual = Map.MapObject<G72_AllowanceOrCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "Wd";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wd", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G72_AllowanceOrCharge();
		subject.AllowanceOrChargeCode = "I";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
