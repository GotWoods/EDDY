using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class C080Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:f:S:z:7:H";

		var expected = new C080_PartyName()
		{
			PartyName = "w",
			PartyName2 = "f",
			PartyName3 = "S",
			PartyName4 = "z",
			PartyName5 = "7",
			PartyNameFormatCode = "H",
		};

		var actual = Map.MapComposite<C080_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new C080_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
