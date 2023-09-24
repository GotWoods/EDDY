using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RIC*kFd*U*s*3*n*S*B*PP*bMA*l*h*PK*LS6*1*Z*OB*Frf*aTZoFzvu";

		var expected = new RIC_FinancialReturn()
		{
			PaymentMethodCode = "kFd",
			CodeListQualifierCode = "U",
			IndustryCode = "s",
			MonetaryAmount = 3,
			CreditDebitFlagCode = "n",
			AccountNumber = "S",
			AccountNumberQualifier = "B",
			DFIIDNumberQualifier = "PP",
			DFIIdentificationNumber = "bMA",
			AccountNumber2 = "l",
			AccountNumberQualifier2 = "h",
			DFIIDNumberQualifier2 = "PK",
			DFIIdentificationNumber2 = "LS6",
			AccountNumber3 = "1",
			AccountNumberQualifier3 = "Z",
			DFIIDNumberQualifier3 = "OB",
			DFIIdentificationNumber3 = "Frf",
			Date = "aTZoFzvu",
		};

		var actual = Map.MapObject<RIC_FinancialReturn>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kFd", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.CreditDebitFlagCode = "n";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "S", true)]
	[InlineData("B", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("PP", "bMA", true)]
	[InlineData("", "bMA", false)]
	[InlineData("PP", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "l", true)]
	[InlineData("h", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier2(string accountNumberQualifier2, string accountNumber2, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.AccountNumberQualifier2 = accountNumberQualifier2;
		subject.AccountNumber2 = accountNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("PK", "LS6", true)]
	[InlineData("", "LS6", false)]
	[InlineData("PK", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1", true)]
	[InlineData("Z", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier3(string accountNumberQualifier3, string accountNumber3, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.AccountNumberQualifier3 = accountNumberQualifier3;
		subject.AccountNumber3 = accountNumber3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("OB", "Frf", true)]
	[InlineData("", "Frf", false)]
	[InlineData("OB", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier3(string dFIIDNumberQualifier3, string dFIIdentificationNumber3, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "kFd";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "s";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "n";
		subject.DFIIDNumberQualifier3 = dFIIDNumberQualifier3;
		subject.DFIIdentificationNumber3 = dFIIdentificationNumber3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
