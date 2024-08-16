using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E966Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:i:a:U:A";

		var expected = new E966_ContactInformation()
		{
			PartyFunctionCodeQualifier = "h",
			CommunicationNumber = "i",
			CommunicationMediumTypeCode = "a",
			PartyName = "U",
			ReferenceIdentifier = "A",
		};

		var actual = Map.MapComposite<E966_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.CommunicationNumber = "i";
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.PartyFunctionCodeQualifier = "h";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
