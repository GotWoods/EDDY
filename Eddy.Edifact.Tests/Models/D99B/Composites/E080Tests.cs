using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E080Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:i:W:3:J:1";

		var expected = new E080_PartyName()
		{
			PartyName = "P",
			PartyName2 = "i",
			PartyName3 = "W",
			PartyName4 = "3",
			PartyName5 = "J",
			PartyNameFormatCode = "1",
		};

		var actual = Map.MapComposite<E080_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E080_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
