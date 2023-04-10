using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

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
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Q", true)]
	public void Validatation_RequiredPaymentHandlingCode(string paymentHandlingCode, bool isValidExpected)
	{
		var subject = new CPI_ClaimantPaymentInformation();
		subject.PaymentHandlingCode = paymentHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
