using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F05*j2*p*g";

		var expected = new F05_AllowanceChargeClaim()
		{
			ChargeAllowanceQualifier = "j2",
			Amount = "p",
			CreditDebitFlagCode = "g",
		};

		var actual = Map.MapObject<F05_AllowanceChargeClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j2", true)]
	public void Validation_RequiredChargeAllowanceQualifier(string chargeAllowanceQualifier, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.Amount = "p";
		subject.CreditDebitFlagCode = "g";
		subject.ChargeAllowanceQualifier = chargeAllowanceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.ChargeAllowanceQualifier = "j2";
		subject.CreditDebitFlagCode = "g";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new F05_AllowanceChargeClaim();
		subject.ChargeAllowanceQualifier = "j2";
		subject.Amount = "p";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
