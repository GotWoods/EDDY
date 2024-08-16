using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class PRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRT+f++s+";

		var expected = new PRT_PartyInformation()
		{
			PartyFunctionCodeQualifier = "f",
			ObjectIdentification = null,
			Date = "s",
			PartyDemographicInformation = null,
		};

		var actual = Map.MapObject<PRT_PartyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new PRT_PartyInformation();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
