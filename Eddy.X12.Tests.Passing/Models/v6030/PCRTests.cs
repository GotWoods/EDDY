using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class PCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCR*yu0*7";

		var expected = new PCR_PaymentCancellationRequest()
		{
			PaymentCancellationTypeCode = "yu0",
			MonetaryAmount = 7,
		};

		var actual = Map.MapObject<PCR_PaymentCancellationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yu0", true)]
	public void Validation_RequiredPaymentCancellationTypeCode(string paymentCancellationTypeCode, bool isValidExpected)
	{
		var subject = new PCR_PaymentCancellationRequest();
		subject.MonetaryAmount = 7;
		subject.PaymentCancellationTypeCode = paymentCancellationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PCR_PaymentCancellationRequest();
		subject.PaymentCancellationTypeCode = "yu0";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
