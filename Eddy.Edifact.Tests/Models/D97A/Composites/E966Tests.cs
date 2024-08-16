using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E966Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "N:8:H:r";

		var expected = new E966_ContactInformation()
		{
			PartyQualifier = "N",
			CommunicationNumber = "8",
			CommunicationChannelQualifier = "H",
			PartyName = "r",
		};

		var actual = Map.MapComposite<E966_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.CommunicationNumber = "8";
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new E966_ContactInformation();
		//Required fields
		subject.PartyQualifier = "N";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
