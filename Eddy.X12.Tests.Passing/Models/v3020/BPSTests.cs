using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPS*4dL*5*O*2f*b2o*O*mFvs0MwItW*0kP7j3JRu*tf*ado*V*G9G7XU*TUIHiQ";

		var expected = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			PaymentMethodCode = "4dL",
			MonetaryAmount = 5,
			TransactionHandlingCode = "O",
			DFIIDNumberQualifier = "2f",
			DFIIdentificationNumber = "b2o",
			AccountNumber = "O",
			OriginatingCompanyIdentifier = "mFvs0MwItW",
			OriginatingCompanySupplementalCode = "0kP7j3JRu",
			DFIIDNumberQualifier2 = "tf",
			DFIIdentificationNumber2 = "ado",
			AccountNumber2 = "V",
			EffectiveEntryDate = "G9G7XU",
			SettlementDate = "TUIHiQ",
		};

		var actual = Map.MapObject<BPS_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4dL", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.MonetaryAmount = 5;
		subject.TransactionHandlingCode = "O";
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "4dL";
		subject.TransactionHandlingCode = "O";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "4dL";
		subject.MonetaryAmount = 5;
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
