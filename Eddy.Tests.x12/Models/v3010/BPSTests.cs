using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPS*aiL*4*U*za*hyn*4*7biLUM4Nol*5gtABUMUo*8A*Owr*1*9GupNg*r15aR8";

		var expected = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			PaymentMethodCode = "aiL",
			MonetaryAmount = 4,
			TransactionHandlingCode = "U",
			DFIIDNumberQualifier = "za",
			DFIIdentificationNumber = "hyn",
			AccountNumber = "4",
			OriginatingCompanyIDNumber = "7biLUM4Nol",
			OriginatingCompanySupplementalCode = "5gtABUMUo",
			DFIIDNumberQualifier2 = "8A",
			DFIIdentificationNumber2 = "Owr",
			AccountNumber2 = "1",
			EffectiveEntryDate = "9GupNg",
			SettlementDate = "r15aR8",
		};

		var actual = Map.MapObject<BPS_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aiL", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.MonetaryAmount = 4;
		subject.TransactionHandlingCode = "U";
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "aiL";
		subject.TransactionHandlingCode = "U";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "aiL";
		subject.MonetaryAmount = 4;
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
