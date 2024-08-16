using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E966Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "z:g:N:6:5";

		var expected = new E966_ContactInformation()
		{
			PartyFunctionCodeQualifier = "z",
			CommunicationAddressIdentifier = "g",
			CommunicationMediumTypeCode = "N",
			PartyName = "6",
			ReferenceIdentifier = "5",
		};

		var actual = Map.MapComposite<E966_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.CommunicationAddressIdentifier = "g";
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredCommunicationAddressIdentifier(string communicationAddressIdentifier, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.PartyFunctionCodeQualifier = "z";
		//Test Parameters
		subject.CommunicationAddressIdentifier = communicationAddressIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
