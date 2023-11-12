using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPR*6*5*E*1tY*i*4J*8qg*H*x*KDYV6q9Nul*nz1DEEwQo*Ca*CBL*Y*7*wWqIjX*q*fI*lYy*r*Z";

		var expected = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			TransactionHandlingCode = "6",
			MonetaryAmount = 5,
			CreditDebitFlagCode = "E",
			PaymentMethodCode = "1tY",
			PaymentFormatCode = "i",
			DFIIDNumberQualifier = "4J",
			DFIIdentificationNumber = "8qg",
			AccountNumberQualifier = "H",
			AccountNumber = "x",
			OriginatingCompanyIdentifier = "KDYV6q9Nul",
			OriginatingCompanySupplementalCode = "nz1DEEwQo",
			DFIIDNumberQualifier2 = "Ca",
			DFIIdentificationNumber2 = "CBL",
			AccountNumberQualifier2 = "Y",
			AccountNumber2 = "7",
			Date = "wWqIjX",
			BusinessFunctionCode = "q",
			DFIIDNumberQualifier3 = "fI",
			DFIIdentificationNumber3 = "lYy",
			AccountNumberQualifier3 = "r",
			AccountNumber3 = "Z",
		};

		var actual = Map.MapObject<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1tY", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4J", "8qg", true)]
	[InlineData("4J", "", false)]
	[InlineData("", "8qg", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "x", true)]
	[InlineData("H", "", false)]
	[InlineData("", "x", true)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ca", "CBL", true)]
	[InlineData("Ca", "", false)]
	[InlineData("", "CBL", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "7", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBAccountNumberQualifier2(string accountNumberQualifier2, string accountNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.AccountNumberQualifier2 = accountNumberQualifier2;
		subject.AccountNumber2 = accountNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fI", "lYy", true)]
	[InlineData("fI", "", false)]
	[InlineData("", "lYy", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier3(string dFIIDNumberQualifier3, string dFIIdentificationNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.DFIIDNumberQualifier3 = dFIIDNumberQualifier3;
		subject.DFIIdentificationNumber3 = dFIIdentificationNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "Z", true)]
	[InlineData("r", "", false)]
	[InlineData("", "Z", true)]
	public void Validation_ARequiresBAccountNumberQualifier3(string accountNumberQualifier3, string accountNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "6";
		subject.MonetaryAmount = 5;
		subject.CreditDebitFlagCode = "E";
		subject.PaymentMethodCode = "1tY";
		//Test Parameters
		subject.AccountNumberQualifier3 = accountNumberQualifier3;
		subject.AccountNumber3 = accountNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4J";
			subject.DFIIdentificationNumber = "8qg";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "Ca";
			subject.DFIIdentificationNumber2 = "CBL";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "fI";
			subject.DFIIdentificationNumber3 = "lYy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
