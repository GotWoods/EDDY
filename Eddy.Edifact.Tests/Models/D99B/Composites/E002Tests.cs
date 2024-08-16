using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:L:5:A:A:9";

		var expected = new E002_CommissionDetails()
		{
			PaymentConditionsCoded = "H",
			MonetaryAmountValue = "L",
			CurrencyIdentificationCode = "5",
			PartyName = "A",
			FreeTextValue = "A",
			ActionRequestNotificationDescriptionCode = "9",
		};

		var actual = Map.MapComposite<E002_CommissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredPaymentConditionsCoded(string paymentConditionsCoded, bool isValidExpected)
	{
		var subject = new E002_CommissionDetails();
		//Required fields
		//Test Parameters
		subject.PaymentConditionsCoded = paymentConditionsCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
