using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class CPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPI*Ju*3*L";

		var expected = new CPI_ClaimantPaymentInformation()
		{
			PaymentHandlingCode = "Ju",
			MonetaryAmount = 3,
			Description = "L",
		};

		var actual = Map.MapObject<CPI_ClaimantPaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ju", true)]
	public void Validation_RequiredPaymentHandlingCode(string paymentHandlingCode, bool isValidExpected)
	{
		var subject = new CPI_ClaimantPaymentInformation();
		//Required fields
		//Test Parameters
		subject.PaymentHandlingCode = paymentHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
