using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E978Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:1:9:R:V";

		var expected = new E978_CreditCardInformation()
		{
			PartyName = "e",
			ReferenceIdentifier = "1",
			Date = "9",
			BankIdentifier = "R",
			TravellerReferenceIdentifier = "V",
		};

		var actual = Map.MapComposite<E978_CreditCardInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E978_CreditCardInformation();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
