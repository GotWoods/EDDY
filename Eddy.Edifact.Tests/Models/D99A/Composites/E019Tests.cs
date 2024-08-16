using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E019Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:j:k:R:0:b:l:z";

		var expected = new E019_PromotionDetails()
		{
			PartyName = "A",
			YesNoIndicatorCoded = "j",
			ReferenceNumber = "k",
			FreeText = "R",
			FreeText2 = "0",
			FreeText3 = "b",
			FreeText4 = "l",
			FreeText5 = "z",
		};

		var actual = Map.MapComposite<E019_PromotionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E019_PromotionDetails();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
