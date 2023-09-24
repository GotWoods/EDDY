using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G14*k*Ah*q1*z*y*X";

		var expected = new G14_TotalAllowanceChargeAdjustment()
		{
			CreditDebitFlagCode = "k",
			AmountOfAdjustment = "Ah",
			AdjustmentReasonCode = "q1",
			FreeFormDescription = "z",
			AllowanceOrChargeCode = "y",
			AllowanceOrChargeNumber = "X",
		};

		var actual = Map.MapObject<G14_TotalAllowanceChargeAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G14_TotalAllowanceChargeAdjustment();
		subject.AmountOfAdjustment = "Ah";
		subject.AdjustmentReasonCode = "q1";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ah", true)]
	public void Validation_RequiredAmountOfAdjustment(string amountOfAdjustment, bool isValidExpected)
	{
		var subject = new G14_TotalAllowanceChargeAdjustment();
		subject.CreditDebitFlagCode = "k";
		subject.AdjustmentReasonCode = "q1";
		subject.AmountOfAdjustment = amountOfAdjustment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q1", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new G14_TotalAllowanceChargeAdjustment();
		subject.CreditDebitFlagCode = "k";
		subject.AmountOfAdjustment = "Ah";
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
