using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S009Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:d:i:u:V";

		var expected = new S009_MessageIdentifier()
		{
			MessageType = "a",
			MessageVersionNumber = "d",
			MessageReleaseNumber = "i",
			ControllingAgency = "u",
			AssociationAssignedCode = "V",
		};

		var actual = Map.MapComposite<S009_MessageIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredMessageType(string messageType, bool isValidExpected)
	{
		var subject = new S009_MessageIdentifier();
		//Required fields
		subject.MessageVersionNumber = "d";
		subject.MessageReleaseNumber = "i";
		subject.ControllingAgency = "u";
		//Test Parameters
		subject.MessageType = messageType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredMessageVersionNumber(string messageVersionNumber, bool isValidExpected)
	{
		var subject = new S009_MessageIdentifier();
		//Required fields
		subject.MessageType = "a";
		subject.MessageReleaseNumber = "i";
		subject.ControllingAgency = "u";
		//Test Parameters
		subject.MessageVersionNumber = messageVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredMessageReleaseNumber(string messageReleaseNumber, bool isValidExpected)
	{
		var subject = new S009_MessageIdentifier();
		//Required fields
		subject.MessageType = "a";
		subject.MessageVersionNumber = "d";
		subject.ControllingAgency = "u";
		//Test Parameters
		subject.MessageReleaseNumber = messageReleaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredControllingAgency(string controllingAgency, bool isValidExpected)
	{
		var subject = new S009_MessageIdentifier();
		//Required fields
		subject.MessageType = "a";
		subject.MessageVersionNumber = "d";
		subject.MessageReleaseNumber = "i";
		//Test Parameters
		subject.ControllingAgency = controllingAgency;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
