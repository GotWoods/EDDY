using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ACSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACS*u*Foj*F*Wv";

		var expected = new ACS_AncillaryCharges()
		{
			Charge = "u",
			SpecialChargeOrAllowanceCode = "Foj",
			Description = "F",
			ShipmentMethodOfPayment = "Wv",
		};

		var actual = Map.MapObject<ACS_AncillaryCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.SpecialChargeOrAllowanceCode = "Foj";
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Foj", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.Charge = "u";
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
