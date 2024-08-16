using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E978Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Z:v:D:a:A";

		var expected = new E978_CreditCardInformation()
		{
			PartyName = "Z",
			ReferenceIdentifier = "v",
			Date = "D",
			BankIdentifier = "a",
			TravellerReferenceIdentifier = "A",
		};

		var actual = Map.MapComposite<E978_CreditCardInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E978_CreditCardInformation();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
