using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ACSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACS*0*ZdO*n*qz";

		var expected = new ACS_AncillaryCharges()
		{
			Amount = "0",
			SpecialChargeOrAllowanceCode = "ZdO",
			Description = "n",
			ShipmentMethodOfPayment = "qz",
		};

		var actual = Map.MapObject<ACS_AncillaryCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.SpecialChargeOrAllowanceCode = "ZdO";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZdO", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.Amount = "0";
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
