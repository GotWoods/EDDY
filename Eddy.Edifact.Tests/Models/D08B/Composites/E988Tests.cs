using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E988Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "R:a:h";

		var expected = new E988_CompanyIdentification()
		{
			PartyName = "R",
			PartyName2 = "a",
			PartyName3 = "h",
		};

		var actual = Map.MapComposite<E988_CompanyIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E988_CompanyIdentification();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
