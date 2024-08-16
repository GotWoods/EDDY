using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class NAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAM+n+++I+q+";

		var expected = new NAM_PartyName()
		{
			PartyFunctionCodeQualifier = "n",
			ObjectIdentification = null,
			PartyIdentificationDetails = null,
			NameTypeCoded = "I",
			NameStatusCoded = "q",
			NameComponentDetails = null,
		};

		var actual = Map.MapObject<NAM_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new NAM_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
