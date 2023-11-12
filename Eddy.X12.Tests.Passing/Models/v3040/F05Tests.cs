using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class F05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F05*6K*Q*B";

		var expected = new F05_AllowanceChargeClaim()
		{
			ChargeAllowanceQualifier = "6K",
			Amount = "Q",
			CreditDebitFlagCode = "B",
		};

		var actual = Map.MapObject<F05_AllowanceChargeClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6K", true)]
	public void Validation_RequiredChargeAllowanceQualifier(string chargeAllowanceQualifier, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.Amount = "Q";
		subject.CreditDebitFlagCode = "B";
		subject.ChargeAllowanceQualifier = chargeAllowanceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.ChargeAllowanceQualifier = "6K";
		subject.CreditDebitFlagCode = "B";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.ChargeAllowanceQualifier = "6K";
		subject.Amount = "Q";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
