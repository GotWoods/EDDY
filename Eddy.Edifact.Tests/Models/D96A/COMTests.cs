using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class COMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "COM+";

		var expected = new COM_CommunicationContact()
		{
			CommunicationContact = null,
		};

		var actual = Map.MapObject<COM_CommunicationContact>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCommunicationContact(string communicationContact, bool isValidExpected)
	{
		var subject = new COM_CommunicationContact();
		//Required fields
		//Test Parameters
		if (communicationContact != "") 
			subject.CommunicationContact = new C076_CommunicationContact();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
