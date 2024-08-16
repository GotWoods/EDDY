using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:s:B:V:x:5";

		var expected = new E002_CommissionDetails()
		{
			PaymentConditionsCode = "S",
			MonetaryAmount = "s",
			CurrencyIdentificationCode = "B",
			PartyName = "V",
			FreeText = "x",
			ActionCode = "5",
		};

		var actual = Map.MapComposite<E002_CommissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredPaymentConditionsCode(string paymentConditionsCode, bool isValidExpected)
	{
		var subject = new E002_CommissionDetails();
		//Required fields
		//Test Parameters
		subject.PaymentConditionsCode = paymentConditionsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
