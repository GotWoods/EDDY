using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA1*983383952*Coz8xb*HddR*O*K40";

		var expected = new TA1_InterchangeAcknowledgment()
		{
			InterchangeControlNumber = 983383952,
			InterchangeDate = "Coz8xb",
			InterchangeTime = "HddR",
			InterchangeAcknowledgmentCode = "O",
			InterchangeNoteCode = "K40",
		};

		var actual = Map.MapObject<TA1_InterchangeAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(983383952, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		subject.InterchangeDate = "Coz8xb";
		subject.InterchangeTime = "HddR";
		subject.InterchangeAcknowledgmentCode = "O";
		subject.InterchangeNoteCode = "K40";
		if (interchangeControlNumber > 0)
		subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Coz8xb", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		subject.InterchangeControlNumber = 983383952;
		subject.InterchangeTime = "HddR";
		subject.InterchangeAcknowledgmentCode = "O";
		subject.InterchangeNoteCode = "K40";
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HddR", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		subject.InterchangeControlNumber = 983383952;
		subject.InterchangeDate = "Coz8xb";
		subject.InterchangeAcknowledgmentCode = "O";
		subject.InterchangeNoteCode = "K40";
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredInterchangeAcknowledgmentCode(string interchangeAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		subject.InterchangeControlNumber = 983383952;
		subject.InterchangeDate = "Coz8xb";
		subject.InterchangeTime = "HddR";
		subject.InterchangeNoteCode = "K40";
		subject.InterchangeAcknowledgmentCode = interchangeAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K40", true)]
	public void Validation_RequiredInterchangeNoteCode(string interchangeNoteCode, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		subject.InterchangeControlNumber = 983383952;
		subject.InterchangeDate = "Coz8xb";
		subject.InterchangeTime = "HddR";
		subject.InterchangeAcknowledgmentCode = "O";
		subject.InterchangeNoteCode = interchangeNoteCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
