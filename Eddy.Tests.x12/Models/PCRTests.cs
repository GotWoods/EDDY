using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCR*RbJ*5";

		var expected = new PCR_PaymentCancellationRequest()
		{
			PaymentCancellationTypeCode = "RbJ",
			MonetaryAmount = 5,
		};

		var actual = Map.MapObject<PCR_PaymentCancellationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RbJ", true)]
	public void Validation_RequiredPaymentCancellationTypeCode(string paymentCancellationTypeCode, bool isValidExpected)
	{
		var subject = new PCR_PaymentCancellationRequest();
		subject.MonetaryAmount = 5;
		subject.PaymentCancellationTypeCode = paymentCancellationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PCR_PaymentCancellationRequest();
		subject.PaymentCancellationTypeCode = "RbJ";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
