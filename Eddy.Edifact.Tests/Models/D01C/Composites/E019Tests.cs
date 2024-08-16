using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E019Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:N:E:1:B:0:R:V";

		var expected = new E019_PromotionDetails()
		{
			PartyName = "n",
			YesOrNoIndicatorCode = "N",
			ReferenceIdentifier = "E",
			FreeText = "1",
			FreeText2 = "B",
			FreeText3 = "0",
			FreeText4 = "R",
			FreeText5 = "V",
		};

		var actual = Map.MapComposite<E019_PromotionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E019_PromotionDetails();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
