using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E019Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:w:s:X:b:B:z:J";

		var expected = new E019_PromotionDetails()
		{
			PartyName = "6",
			YesOrNoIndicatorCode = "w",
			ReferenceIdentifier = "s",
			FreeTextValue = "X",
			FreeTextValue2 = "b",
			FreeTextValue3 = "B",
			FreeTextValue4 = "z",
			FreeTextValue5 = "J",
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
