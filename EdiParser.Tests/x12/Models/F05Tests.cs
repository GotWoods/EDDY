using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class F05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F05*cK*0*T";

		var expected = new F05_AllowanceChargeClaim()
		{
			ChargeAllowanceQualifier = "cK",
			Amount = "0",
			CreditDebitFlagCode = "T",
		};

		var actual = Map.MapObject<F05_AllowanceChargeClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cK", true)]
	public void Validatation_RequiredChargeAllowanceQualifier(string chargeAllowanceQualifier, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.Amount = "0";
		subject.CreditDebitFlagCode = "T";
		subject.ChargeAllowanceQualifier = chargeAllowanceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.ChargeAllowanceQualifier = "cK";
		subject.CreditDebitFlagCode = "T";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validatation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.ChargeAllowanceQualifier = "cK";
		subject.Amount = "0";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
