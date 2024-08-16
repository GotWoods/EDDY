using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E019Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:g:W:q:J:X:n:9";

		var expected = new E019_PromotionDetails()
		{
			PartyName = "6",
			YesOrNoIndicatorCode = "g",
			ReferenceIdentifier = "W",
			FreeTextValue = "q",
			FreeTextValue2 = "J",
			FreeTextValue3 = "X",
			FreeTextValue4 = "n",
			FreeTextValue5 = "9",
		};

		var actual = Map.MapComposite<E019_PromotionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E019_PromotionDetails();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
