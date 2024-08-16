using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S306Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "I:4:8:5:i:R";

		var expected = new S306_InteractiveMessageIdentifier()
		{
			MessageType = "I",
			MessageVersionNumber = "4",
			MessageReleaseNumber = "8",
			MessageTypeSubFunctionIdentification = "5",
			ControllingAgencyCoded = "i",
			AssociationAssignedCode = "R",
		};

		var actual = Map.MapComposite<S306_InteractiveMessageIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredMessageType(string messageType, bool isValidExpected)
	{
		var subject = new S306_InteractiveMessageIdentifier();
		//Required fields
		subject.MessageVersionNumber = "4";
		subject.MessageReleaseNumber = "8";
		//Test Parameters
		subject.MessageType = messageType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredMessageVersionNumber(string messageVersionNumber, bool isValidExpected)
	{
		var subject = new S306_InteractiveMessageIdentifier();
		//Required fields
		subject.MessageType = "I";
		subject.MessageReleaseNumber = "8";
		//Test Parameters
		subject.MessageVersionNumber = messageVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredMessageReleaseNumber(string messageReleaseNumber, bool isValidExpected)
	{
		var subject = new S306_InteractiveMessageIdentifier();
		//Required fields
		subject.MessageType = "I";
		subject.MessageVersionNumber = "4";
		//Test Parameters
		subject.MessageReleaseNumber = messageReleaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
