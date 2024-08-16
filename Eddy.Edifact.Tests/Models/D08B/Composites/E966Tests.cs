using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E966Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "I:5:M:5:X";

		var expected = new E966_ContactInformation()
		{
			PartyFunctionCodeQualifier = "I",
			CommunicationAddressIdentifier = "5",
			CommunicationMediumTypeCode = "M",
			PartyName = "5",
			ReferenceIdentifier = "X",
		};

		var actual = Map.MapComposite<E966_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.CommunicationAddressIdentifier = "5";
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredCommunicationAddressIdentifier(string communicationAddressIdentifier, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.PartyFunctionCodeQualifier = "I";
		//Test Parameters
		subject.CommunicationAddressIdentifier = communicationAddressIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
