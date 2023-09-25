using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPR*F*2*U*N17*P*iY*UxF*u*3*4fQV9dUWxj*qJdkzuodZ*Sv*gFm*9*J*wt5VsWD9*k*9a*ki0*i*R";

		var expected = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			TransactionHandlingCode = "F",
			MonetaryAmount = 2,
			CreditDebitFlagCode = "U",
			PaymentMethodCode = "N17",
			PaymentFormatCode = "P",
			DFIIDNumberQualifier = "iY",
			DFIIdentificationNumber = "UxF",
			AccountNumberQualifier = "u",
			AccountNumber = "3",
			OriginatingCompanyIdentifier = "4fQV9dUWxj",
			OriginatingCompanySupplementalCode = "qJdkzuodZ",
			DFIIDNumberQualifier2 = "Sv",
			DFIIdentificationNumber2 = "gFm",
			AccountNumberQualifier2 = "9",
			AccountNumber2 = "J",
			Date = "wt5VsWD9",
			BusinessFunctionCode = "k",
			DFIIDNumberQualifier3 = "9a",
			DFIIdentificationNumber3 = "ki0",
			AccountNumberQualifier3 = "i",
			AccountNumber3 = "R",
		};

		var actual = Map.MapObject<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
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
		subject.TransactionHandlingCode = "F";
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N17", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iY", "UxF", true)]
	[InlineData("iY", "", false)]
	[InlineData("", "UxF", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "3", true)]
	[InlineData("u", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sv", "gFm", true)]
	[InlineData("Sv", "", false)]
	[InlineData("", "gFm", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "J", true)]
	[InlineData("9", "", false)]
	[InlineData("", "J", true)]
	public void Validation_ARequiresBAccountNumberQualifier2(string accountNumberQualifier2, string accountNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.AccountNumberQualifier2 = accountNumberQualifier2;
		subject.AccountNumber2 = accountNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9a", "ki0", true)]
	[InlineData("9a", "", false)]
	[InlineData("", "ki0", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier3(string dFIIDNumberQualifier3, string dFIIdentificationNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.DFIIDNumberQualifier3 = dFIIDNumberQualifier3;
		subject.DFIIdentificationNumber3 = dFIIdentificationNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "R", true)]
	[InlineData("i", "", false)]
	[InlineData("", "R", true)]
	public void Validation_ARequiresBAccountNumberQualifier3(string accountNumberQualifier3, string accountNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "F";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "U";
		subject.PaymentMethodCode = "N17";
		//Test Parameters
		subject.AccountNumberQualifier3 = accountNumberQualifier3;
		subject.AccountNumber3 = accountNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iY";
			subject.DFIIdentificationNumber = "UxF";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Sv";
			subject.DFIIdentificationNumber2 = "gFm";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "9a";
			subject.DFIIdentificationNumber3 = "ki0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
