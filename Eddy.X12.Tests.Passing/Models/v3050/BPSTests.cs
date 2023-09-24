using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPS*RTy*6*Q*5e*g8I*3*fFEd9VyDzb*7HJJk94NR*V3*HJF*i*UPxds8*CoP7iZ";

		var expected = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice()
		{
			PaymentMethodCode = "RTy",
			MonetaryAmount = 6,
			TransactionHandlingCode = "Q",
			DFIIDNumberQualifier = "5e",
			DFIIdentificationNumber = "g8I",
			AccountNumber = "3",
			OriginatingCompanyIdentifier = "fFEd9VyDzb",
			OriginatingCompanySupplementalCode = "7HJJk94NR",
			DFIIDNumberQualifier2 = "V3",
			DFIIdentificationNumber2 = "HJF",
			AccountNumber2 = "i",
			Date = "UPxds8",
			Date2 = "CoP7iZ",
		};

		var actual = Map.MapObject<BPS_BeginningSegmentForPaymentOrderRemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RTy", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.MonetaryAmount = 6;
		subject.TransactionHandlingCode = "Q";
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "RTy";
		subject.TransactionHandlingCode = "Q";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BPS_BeginningSegmentForPaymentOrderRemittanceAdvice();
		subject.PaymentMethodCode = "RTy";
		subject.MonetaryAmount = 6;
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
