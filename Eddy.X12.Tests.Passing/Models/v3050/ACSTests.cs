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
		string x12Line = "ACS*a*Yit*D*9H";

		var expected = new ACS_AncillaryCharges()
		{
			Amount = "a",
			SpecialChargeOrAllowanceCode = "Yit",
			Description = "D",
			ShipmentMethodOfPayment = "9H",
		};

		var actual = Map.MapObject<ACS_AncillaryCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.SpecialChargeOrAllowanceCode = "Yit";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yit", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.Amount = "a";
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
