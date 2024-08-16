using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C076Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "q:e";

		var expected = new C076_CommunicationContact()
		{
			CommunicationNumber = "q",
			CommunicationNumberCodeQualifier = "e",
		};

		var actual = Map.MapComposite<C076_CommunicationContact>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationNumberCodeQualifier = "e";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredCommunicationNumberCodeQualifier(string communicationNumberCodeQualifier, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationNumber = "q";
		//Test Parameters
		subject.CommunicationNumberCodeQualifier = communicationNumberCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
