using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCR*Rhh*2";

		var expected = new PCR_PaymentCancellationRequest()
		{
			PaymentCancellationType = "Rhh",
			MonetaryAmount = 2,
		};

		var actual = Map.MapObject<PCR_PaymentCancellationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rhh", true)]
	public void Validation_RequiredPaymentCancellationType(string paymentCancellationType, bool isValidExpected)
	{
		var subject = new PCR_PaymentCancellationRequest();
		subject.MonetaryAmount = 2;
		subject.PaymentCancellationType = paymentCancellationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PCR_PaymentCancellationRequest();
		subject.PaymentCancellationType = "Rhh";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
