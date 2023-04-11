using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPI*9Q*1*G";

		var expected = new CPI_ClaimantPaymentInformation()
		{
			PaymentHandlingCode = "9Q",
			MonetaryAmount = 1,
			Description = "G",
		};

		var actual = Map.MapObject<CPI_ClaimantPaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Q", true)]
	public void Validation_RequiredPaymentHandlingCode(string paymentHandlingCode, bool isValidExpected)
	{
		var subject = new CPI_ClaimantPaymentInformation();
		subject.PaymentHandlingCode = paymentHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
