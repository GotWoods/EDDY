using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E019Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "J:F:B:b:P:C:z:t";

		var expected = new E019_PromotionDetails()
		{
			PartyName = "J",
			YesOrNoIndicatorCode = "F",
			ReferenceIdentifier = "B",
			FreeText = "b",
			FreeText2 = "P",
			FreeText3 = "C",
			FreeText4 = "z",
			FreeText5 = "t",
		};

		var actual = Map.MapComposite<E019_PromotionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E019_PromotionDetails();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
