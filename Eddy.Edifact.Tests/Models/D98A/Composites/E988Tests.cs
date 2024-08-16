using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E988Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "G:X:c";

		var expected = new E988_CompanyIdentification()
		{
			PartyName = "G",
			PartyName2 = "X",
			PartyName3 = "c",
		};

		var actual = Map.MapComposite<E988_CompanyIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E988_CompanyIdentification();
		//Required fields
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
