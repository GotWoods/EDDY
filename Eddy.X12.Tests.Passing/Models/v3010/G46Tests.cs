using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G46Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G46*O*Wi*2*qO*F*g*1*g*X*w*8";

		var expected = new G46_PromotionAllowanceCharge()
		{
			AllowanceOrChargeCode = "O",
			AllowanceOrChargeMethodOfHandlingCode = "Wi",
			AllowanceOrChargeRate = 2,
			UnitOfMeasurementCode = "qO",
			AllowanceOrChargeTotalAmount = "F",
			AllowanceChargePercentQualifier = "g",
			AllowanceOrChargePercent = 1,
			ExceptionNumber = "g",
			OptionNumber = "X",
			FreeFormMessage = "w",
			TermsDiscountDaysDue = 8,
		};

		var actual = Map.MapObject<G46_PromotionAllowanceCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "Wi";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wi", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "O";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
