using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPR*C*1*8*Sqn*F*4g*uKD*P3*q*b8dZrMJn5T*o0bwy7UUD*rL*9UX*sn*2*vC6AO8";

		var expected = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			TransactionHandlingCode = "C",
			MonetaryAmount = 1,
			CreditDebitFlagCode = "8",
			PaymentMethodCode = "Sqn",
			PaymentFormat = "F",
			DFIIDNumberQualifier = "4g",
			DFIIdentificationNumber = "uKD",
			AccountNumberQualifierCode = "P3",
			AccountNumber = "q",
			OriginatingCompanyIdentifier = "b8dZrMJn5T",
			OriginatingCompanySupplementalCode = "o0bwy7UUD",
			DFIIDNumberQualifier2 = "rL",
			DFIIdentificationNumber2 = "9UX",
			AccountNumberQualifierCode2 = "sn",
			AccountNumber2 = "2",
			EffectiveEntryDate = "vC6AO8",
		};

		var actual = Map.MapObject<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "8";
		subject.PaymentMethodCode = "Sqn";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4g";
			subject.DFIIdentificationNumber = "uKD";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "rL";
			subject.DFIIdentificationNumber2 = "9UX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "C";
		subject.CreditDebitFlagCode = "8";
		subject.PaymentMethodCode = "Sqn";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4g";
			subject.DFIIdentificationNumber = "uKD";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "rL";
			subject.DFIIdentificationNumber2 = "9UX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "C";
		subject.MonetaryAmount = 1;
		subject.PaymentMethodCode = "Sqn";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4g";
			subject.DFIIdentificationNumber = "uKD";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "rL";
			subject.DFIIdentificationNumber2 = "9UX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sqn", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "C";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "8";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4g";
			subject.DFIIdentificationNumber = "uKD";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "rL";
			subject.DFIIdentificationNumber2 = "9UX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4g", "uKD", true)]
	[InlineData("4g", "", false)]
	[InlineData("", "uKD", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "C";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "8";
		subject.PaymentMethodCode = "Sqn";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "rL";
			subject.DFIIdentificationNumber2 = "9UX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P3", "q", true)]
	[InlineData("P3", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBAccountNumberQualifierCode(string accountNumberQualifierCode, string accountNumber, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "C";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "8";
		subject.PaymentMethodCode = "Sqn";
		//Test Parameters
		subject.AccountNumberQualifierCode = accountNumberQualifierCode;
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4g";
			subject.DFIIdentificationNumber = "uKD";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "rL";
			subject.DFIIdentificationNumber2 = "9UX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rL", "9UX", true)]
	[InlineData("rL", "", false)]
	[InlineData("", "9UX", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "C";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "8";
		subject.PaymentMethodCode = "Sqn";
		//Test Parameters
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4g";
			subject.DFIIdentificationNumber = "uKD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sn", "2", true)]
	[InlineData("sn", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBAccountNumberQualifierCode2(string accountNumberQualifierCode2, string accountNumber2, bool isValidExpected)
	{
		var subject = new BPR_BeginningSegmentForPaymentOrderRemittanceAdvice();
		//Required fields
		subject.TransactionHandlingCode = "C";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "8";
		subject.PaymentMethodCode = "Sqn";
		//Test Parameters
		subject.AccountNumberQualifierCode2 = accountNumberQualifierCode2;
		subject.AccountNumber2 = accountNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "4g";
			subject.DFIIdentificationNumber = "uKD";
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "rL";
			subject.DFIIdentificationNumber2 = "9UX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
