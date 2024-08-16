using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:V:Q:N:z:I";

		var expected = new E002_CommissionDetails()
		{
			PaymentConditionsCode = "E",
			MonetaryAmount = "V",
			CurrencyIdentificationCode = "Q",
			PartyName = "N",
			FreeTextValue = "z",
			ActionRequestNotificationDescriptionCode = "I",
		};

		var actual = Map.MapComposite<E002_CommissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredPaymentConditionsCode(string paymentConditionsCode, bool isValidExpected)
	{
		var subject = new E002_CommissionDetails();
		//Required fields
		//Test Parameters
		subject.PaymentConditionsCode = paymentConditionsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
