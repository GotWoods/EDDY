using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E080Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "C:y:t:h:B:F";

		var expected = new E080_PartyName()
		{
			PartyName = "C",
			PartyName2 = "y",
			PartyName3 = "t",
			PartyName4 = "h",
			PartyName5 = "B",
			PartyNameFormatCode = "F",
		};

		var actual = Map.MapComposite<E080_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E080_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
