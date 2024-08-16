using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C080Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "R:F:I:Z:A:U";

		var expected = new C080_PartyName()
		{
			PartyName = "R",
			PartyName2 = "F",
			PartyName3 = "I",
			PartyName4 = "Z",
			PartyName5 = "A",
			PartyNameFormatCoded = "U",
		};

		var actual = Map.MapComposite<C080_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new C080_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
