using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G15*cd*0";

		var expected = new G15_TotalAdjustmentAmount()
		{
			AmountOfAdjustment = "cd",
			CreditDebitFlagCode = "0",
		};

		var actual = Map.MapObject<G15_TotalAdjustmentAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cd", true)]
	public void Validation_RequiredAmountOfAdjustment(string amountOfAdjustment, bool isValidExpected)
	{
		var subject = new G15_TotalAdjustmentAmount();
		subject.CreditDebitFlagCode = "0";
		subject.AmountOfAdjustment = amountOfAdjustment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G15_TotalAdjustmentAmount();
		subject.AmountOfAdjustment = "cd";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
