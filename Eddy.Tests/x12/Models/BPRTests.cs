using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPR*c*2*k*wya*4*KO*y39*d*7*RIVxIU5cLM*bPZ4ZRWNs*mr*Sw6*D*u*itdXTGCV*W*Ts*jYZ*m*4";

		var expected = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			TransactionHandlingCode = "c",
			MonetaryAmount = 2,
			CreditDebitFlagCode = "k",
			PaymentMethodCode = "wya",
			PaymentFormatCode = "4",
			DFIIDNumberQualifier = "KO",
			DFIIdentificationNumber = "y39",
			AccountNumberQualifier = "d",
			AccountNumber = "7",
			OriginatingCompanyIdentifier = "RIVxIU5cLM",
			OriginatingCompanySupplementalCode = "bPZ4ZRWNs",
			DFIIDNumberQualifier2 = "mr",
			DFIIdentificationNumber2 = "Sw6",
			AccountNumberQualifier2 = "D",
			AccountNumber2 = "u",
			Date = "itdXTGCV",
			BusinessFunctionCode = "W",
			DFIIDNumberQualifier3 = "Ts",
			DFIIdentificationNumber3 = "jYZ",
			AccountNumberQualifier3 = "m",
			AccountNumber3 = "4",
		};

		var actual = Map.MapObject<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validatation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validatation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.PaymentMethodCode = "wya";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wya", true)]
	public void Validatation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("KO", "y39", true)]
	[InlineData("", "y39", false)]
	[InlineData("KO", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "7", true)]
	[InlineData("d", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("mr", "Sw6", true)]
	[InlineData("", "Sw6", false)]
	[InlineData("mr", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "u", true)]
	[InlineData("D", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier2(string accountNumberQualifier2, string accountNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		subject.AccountNumberQualifier2 = accountNumberQualifier2;
		subject.AccountNumber2 = accountNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ts", "jYZ", true)]
	[InlineData("", "jYZ", false)]
	[InlineData("Ts", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier3(string dFIIDNumberQualifier3, string dFIIdentificationNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		subject.DFIIDNumberQualifier3 = dFIIDNumberQualifier3;
		subject.DFIIdentificationNumber3 = dFIIdentificationNumber3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "4", true)]
	[InlineData("m", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier3(string accountNumberQualifier3, string accountNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.TransactionHandlingCode = "c";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "k";
		subject.PaymentMethodCode = "wya";
		subject.AccountNumberQualifier3 = accountNumberQualifier3;
		subject.AccountNumber3 = accountNumber3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
