using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class NAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAM+x+++I+Z+";

		var expected = new NAM_PartyName()
		{
			PartyFunctionCodeQualifier = "x",
			ObjectIdentification = null,
			PartyIdentificationDetails = null,
			NameTypeCode = "I",
			NameStatusCoded = "Z",
			NameComponentDetails = null,
		};

		var actual = Map.MapObject<NAM_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new NAM_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
