using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E978Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:V:u:I:I";

		var expected = new E978_CreditCardInformation()
		{
			PartyName = "f",
			ReferenceIdentifier = "V",
			DateValue = "u",
			BankIdentification = "I",
			TravellerReferenceNumber = "I",
		};

		var actual = Map.MapComposite<E978_CreditCardInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E978_CreditCardInformation();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
