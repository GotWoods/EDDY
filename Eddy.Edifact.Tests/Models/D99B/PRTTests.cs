using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRT+j++a+";

		var expected = new PRT_PartyInformation()
		{
			PartyFunctionCodeQualifier = "j",
			ObjectIdentification = null,
			DateValue = "a",
			PartyDemographicInformation = null,
		};

		var actual = Map.MapObject<PRT_PartyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new PRT_PartyInformation();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
