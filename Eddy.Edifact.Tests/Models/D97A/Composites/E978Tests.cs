using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E978Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:o:N:P:p";

		var expected = new E978_CreditCardInformation()
		{
			PartyName = "X",
			ReferenceNumber = "o",
			Date = "N",
			BankIdentification = "P",
			TravellerReferenceNumber = "p",
		};

		var actual = Map.MapComposite<E978_CreditCardInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E978_CreditCardInformation();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
