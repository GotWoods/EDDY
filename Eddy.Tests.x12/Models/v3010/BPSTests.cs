using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPS*K1T*5*N*3W*ms9*6*pRu1EFIFN5*O2aX8pw8C*MP*thv*f*zNaxWM*xXmdLl";

		var expected = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			PaymentMethodCode = "K1T",
			MonetaryAmount = 5,
			TransactionHandlingCode = "N",
			DFIIDNumberQualifier = "3W",
			DFIIdentificationNumber = "ms9",
			AccountNumber = "6",
			OriginatingCompanyIDNumber = "pRu1EFIFN5",
			OriginatingCompanySupplementalCode = "O2aX8pw8C",
			DFIIDNumberQualifier2 = "MP",
			DFIIdentificationNumber2 = "thv",
			AccountNumber2 = "f",
			EffectiveEntryDate = "zNaxWM",
			SettlementDate = "xXmdLl",
		};

		var actual = Map.MapObject<BPS_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K1T", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.MonetaryAmount = 5;
		subject.TransactionHandlingCode = "N";
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "K1T";
		subject.TransactionHandlingCode = "N";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "K1T";
		subject.MonetaryAmount = 5;
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
