using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C080Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:I:d:B:z:u";

		var expected = new C080_PartyName()
		{
			PartyName = "K",
			PartyName2 = "I",
			PartyName3 = "d",
			PartyName4 = "B",
			PartyName5 = "z",
			PartyNameFormatCode = "u",
		};

		var actual = Map.MapComposite<C080_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new C080_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
