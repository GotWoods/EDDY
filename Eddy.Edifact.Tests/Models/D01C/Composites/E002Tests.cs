using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "j:c:G:C:v:Q";

		var expected = new E002_CommissionDetails()
		{
			PaymentConditionsCode = "j",
			MonetaryAmount = "c",
			CurrencyIdentificationCode = "G",
			PartyName = "C",
			FreeText = "v",
			ActionRequestNotificationDescriptionCode = "Q",
		};

		var actual = Map.MapComposite<E002_CommissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPaymentConditionsCode(string paymentConditionsCode, bool isValidExpected)
	{
		var subject = new E002_CommissionDetails();
		//Required fields
		//Test Parameters
		subject.PaymentConditionsCode = paymentConditionsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
