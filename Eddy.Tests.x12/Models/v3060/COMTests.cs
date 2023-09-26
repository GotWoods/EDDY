using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class COMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COM*Ru*x";

		var expected = new COM_CommunicationContactInformation()
		{
			CommunicationNumberQualifier = "Ru",
			CommunicationNumber = "x",
		};

		var actual = Map.MapObject<COM_CommunicationContactInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ru", "x", true)]
	[InlineData("Ru", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new COM_CommunicationContactInformation();
		//Required fields
		//Test Parameters
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
