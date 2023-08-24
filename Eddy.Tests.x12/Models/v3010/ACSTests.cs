using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ACSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACS*t*tbv*9";

		var expected = new ACS_AncillaryCharges()
		{
			Charge = "t",
			SpecialChargeCode = "tbv",
			Description = "9",
		};

		var actual = Map.MapObject<ACS_AncillaryCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.SpecialChargeCode = "tbv";
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tbv", true)]
	public void Validation_RequiredSpecialChargeCode(string specialChargeCode, bool isValidExpected)
	{
		var subject = new ACS_AncillaryCharges();
		subject.Charge = "t";
		subject.SpecialChargeCode = specialChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
