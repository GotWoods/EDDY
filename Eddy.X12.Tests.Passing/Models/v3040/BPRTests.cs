using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPR*2*3*G*JRT*O*pa*7T6*aZ*i*XawL4NBnEY*gfeBQnxPH*ad*V51*CS*Y*PIch0v*8*NS*H1x*da*h";

		var expected = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			TransactionHandlingCode = "2",
			MonetaryAmount = 3,
			CreditDebitFlagCode = "G",
			PaymentMethodCode = "JRT",
			PaymentFormatCode = "O",
			DFIIDNumberQualifier = "pa",
			DFIIdentificationNumber = "7T6",
			AccountNumberQualifierCode = "aZ",
			AccountNumber = "i",
			OriginatingCompanyIdentifier = "XawL4NBnEY",
			OriginatingCompanySupplementalCode = "gfeBQnxPH",
			DFIIDNumberQualifier2 = "ad",
			DFIIdentificationNumber2 = "V51",
			AccountNumberQualifierCode2 = "CS",
			AccountNumber2 = "Y",
			EffectiveEntryDate = "PIch0v",
			BusinessFunctionCode = "8",
			DFIIDNumberQualifier3 = "NS",
			DFIIdentificationNumber3 = "H1x",
			AccountNumberQualifierCode3 = "da",
			AccountNumber3 = "h",
		};

		var actual = Map.MapObject<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JRT", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pa", "7T6", true)]
	[InlineData("pa", "", false)]
	[InlineData("", "7T6", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aZ", "i", true)]
	[InlineData("aZ", "", false)]
	[InlineData("", "i", true)]
	public void Validation_ARequiresBAccountNumberQualifierCode(string accountNumberQualifierCode, string accountNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.AccountNumberQualifierCode = accountNumberQualifierCode;
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ad", "V51", true)]
	[InlineData("ad", "", false)]
	[InlineData("", "V51", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CS", "Y", true)]
	[InlineData("CS", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBAccountNumberQualifierCode2(string accountNumberQualifierCode2, string accountNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.AccountNumberQualifierCode2 = accountNumberQualifierCode2;
		subject.AccountNumber2 = accountNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NS", "H1x", true)]
	[InlineData("NS", "", false)]
	[InlineData("", "H1x", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier3(string dFIIDNumberQualifier3, string dFIIdentificationNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.DFIIDNumberQualifier3 = dFIIDNumberQualifier3;
		subject.DFIIdentificationNumber3 = dFIIdentificationNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("da", "h", true)]
	[InlineData("da", "", false)]
	[InlineData("", "h", true)]
	public void Validation_ARequiresBAccountNumberQualifierCode3(string accountNumberQualifierCode3, string accountNumber3, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "2";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "G";
		subject.PaymentMethodCode = "JRT";
		//Test Parameters
		subject.AccountNumberQualifierCode3 = accountNumberQualifierCode3;
		subject.AccountNumber3 = accountNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "pa";
			subject.DFIIdentificationNumber = "7T6";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "ad";
			subject.DFIIdentificationNumber2 = "V51";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "NS";
			subject.DFIIdentificationNumber3 = "H1x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
