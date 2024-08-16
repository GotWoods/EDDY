using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:N:x:x:k";

		var expected = new E002_CommissionDetails()
		{
			PaymentConditionsCoded = "P",
			MonetaryAmount = "N",
			CurrencyCoded = "x",
			PartyName = "x",
			FreeText = "k",
		};

		var actual = Map.MapComposite<E002_CommissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredPaymentConditionsCoded(string paymentConditionsCoded, bool isValidExpected)
	{
		var subject = new E002_CommissionDetails();
		//Required fields
		//Test Parameters
		subject.PaymentConditionsCoded = paymentConditionsCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
