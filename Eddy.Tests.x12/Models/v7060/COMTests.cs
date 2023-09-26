using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class COMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COM*Cn*o**UI*C";

		var expected = new COM_CommunicationContactInformation()
		{
			CommunicationNumberQualifier = "Cn",
			CommunicationNumber = "o",
			CommunicationNumberComponent = null,
			LanguageCode = "UI",
			AssignedIdentification = "C",
		};

		var actual = Map.MapObject<COM_CommunicationContactInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cn", true)]
	public void Validation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new COM_CommunicationContactInformation();
		//Required fields
		subject.CommunicationNumber = "o";
		//Test Parameters
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new COM_CommunicationContactInformation();
		//Required fields
		subject.CommunicationNumberQualifier = "Cn";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
