using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPR*0*2*5*4zb*S*c8*6s3*dC*U*wKHy8iRuY1*6fCDOxUVh*Lf*X5X*PP*X*xmUbsa*v";

		var expected = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			TransactionHandlingCode = "0",
			MonetaryAmount = 2,
			CreditDebitFlagCode = "5",
			PaymentMethodCode = "4zb",
			PaymentFormat = "S",
			DFIIDNumberQualifier = "c8",
			DFIIdentificationNumber = "6s3",
			AccountNumberQualifierCode = "dC",
			AccountNumber = "U",
			OriginatingCompanyIdentifier = "wKHy8iRuY1",
			OriginatingCompanySupplementalCode = "6fCDOxUVh",
			DFIIDNumberQualifier2 = "Lf",
			DFIIdentificationNumber2 = "X5X",
			AccountNumberQualifierCode2 = "PP",
			AccountNumber2 = "X",
			EffectiveEntryDate = "xmUbsa",
			BusinessFunctionCode = "v",
		};

		var actual = Map.MapObject<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "5";
		subject.PaymentMethodCode = "4zb";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "c8";
			subject.DFIIdentificationNumber = "6s3";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Lf";
			subject.DFIIdentificationNumber2 = "X5X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "0";
		subject.CreditDebitFlagCode = "5";
		subject.PaymentMethodCode = "4zb";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "c8";
			subject.DFIIdentificationNumber = "6s3";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Lf";
			subject.DFIIdentificationNumber2 = "X5X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "0";
		subject.MonetaryAmount = 2;
		subject.PaymentMethodCode = "4zb";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "c8";
			subject.DFIIdentificationNumber = "6s3";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Lf";
			subject.DFIIdentificationNumber2 = "X5X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4zb", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "0";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "5";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "c8";
			subject.DFIIdentificationNumber = "6s3";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Lf";
			subject.DFIIdentificationNumber2 = "X5X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c8", "6s3", true)]
	[InlineData("c8", "", false)]
	[InlineData("", "6s3", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "0";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "5";
		subject.PaymentMethodCode = "4zb";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Lf";
			subject.DFIIdentificationNumber2 = "X5X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dC", "U", true)]
	[InlineData("dC", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBAccountNumberQualifierCode(string accountNumberQualifierCode, string accountNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "0";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "5";
		subject.PaymentMethodCode = "4zb";
		//Test Parameters
		subject.AccountNumberQualifierCode = accountNumberQualifierCode;
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "c8";
			subject.DFIIdentificationNumber = "6s3";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Lf";
			subject.DFIIdentificationNumber2 = "X5X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lf", "X5X", true)]
	[InlineData("Lf", "", false)]
	[InlineData("", "X5X", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "0";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "5";
		subject.PaymentMethodCode = "4zb";
		//Test Parameters
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "c8";
			subject.DFIIdentificationNumber = "6s3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PP", "X", true)]
	[InlineData("PP", "", false)]
	[InlineData("", "X", true)]
	public void Validation_ARequiresBAccountNumberQualifierCode2(string accountNumberQualifierCode2, string accountNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "0";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "5";
		subject.PaymentMethodCode = "4zb";
		//Test Parameters
		subject.AccountNumberQualifierCode2 = accountNumberQualifierCode2;
		subject.AccountNumber2 = accountNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "c8";
			subject.DFIIdentificationNumber = "6s3";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Lf";
			subject.DFIIdentificationNumber2 = "X5X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
