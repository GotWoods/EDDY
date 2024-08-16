using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C076Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:J";

		var expected = new C076_CommunicationContact()
		{
			CommunicationNumber = "D",
			CommunicationChannelQualifier = "J",
		};

		var actual = Map.MapComposite<C076_CommunicationContact>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationChannelQualifier = "J";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredCommunicationChannelQualifier(string communicationChannelQualifier, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationNumber = "D";
		//Test Parameters
		subject.CommunicationChannelQualifier = communicationChannelQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
