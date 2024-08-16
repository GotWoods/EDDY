using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S009Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:m:M:P:i:N:X";

		var expected = new S009_MessageIdentifier()
		{
			MessageType = "a",
			MessageVersionNumber = "m",
			MessageReleaseNumber = "M",
			ControllingAgencyCoded = "P",
			AssociationAssignedCode = "i",
			CodeListDirectoryVersionNumber = "N",
			MessageTypeSubFunctionIdentification = "X",
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
		subject.MessageVersionNumber = "m";
		subject.MessageReleaseNumber = "M";
		subject.ControllingAgencyCoded = "P";
		//Test Parameters
		subject.MessageType = messageType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredMessageVersionNumber(string messageVersionNumber, bool isValidExpected)
	{
		var subject = new S009_MessageIdentifier();
		//Required fields
		subject.MessageType = "a";
		subject.MessageReleaseNumber = "M";
		subject.ControllingAgencyCoded = "P";
		//Test Parameters
		subject.MessageVersionNumber = messageVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredMessageReleaseNumber(string messageReleaseNumber, bool isValidExpected)
	{
		var subject = new S009_MessageIdentifier();
		//Required fields
		subject.MessageType = "a";
		subject.MessageVersionNumber = "m";
		subject.ControllingAgencyCoded = "P";
		//Test Parameters
		subject.MessageReleaseNumber = messageReleaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredControllingAgencyCoded(string controllingAgencyCoded, bool isValidExpected)
	{
		var subject = new S009_MessageIdentifier();
		//Required fields
		subject.MessageType = "a";
		subject.MessageVersionNumber = "m";
		subject.MessageReleaseNumber = "M";
		//Test Parameters
		subject.ControllingAgencyCoded = controllingAgencyCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
