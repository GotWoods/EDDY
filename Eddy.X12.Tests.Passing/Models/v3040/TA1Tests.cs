using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA1*233194512*zEvEeJ*vx00*m*82B";

		var expected = new TA1_InterchangeAcknowledgment()
		{
			InterchangeControlNumber = 233194512,
			InterchangeDate = "zEvEeJ",
			InterchangeTime = "vx00",
			InterchangeAcknowledgmentCode = "m",
			InterchangeNoteCode = "82B",
		};

		var actual = Map.MapObject<TA1_InterchangeAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(233194512, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		//Required fields
		subject.InterchangeDate = "zEvEeJ";
		subject.InterchangeTime = "vx00";
		subject.InterchangeAcknowledgmentCode = "m";
		subject.InterchangeNoteCode = "82B";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zEvEeJ", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		//Required fields
		subject.InterchangeControlNumber = 233194512;
		subject.InterchangeTime = "vx00";
		subject.InterchangeAcknowledgmentCode = "m";
		subject.InterchangeNoteCode = "82B";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vx00", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		//Required fields
		subject.InterchangeControlNumber = 233194512;
		subject.InterchangeDate = "zEvEeJ";
		subject.InterchangeAcknowledgmentCode = "m";
		subject.InterchangeNoteCode = "82B";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredInterchangeAcknowledgmentCode(string interchangeAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		//Required fields
		subject.InterchangeControlNumber = 233194512;
		subject.InterchangeDate = "zEvEeJ";
		subject.InterchangeTime = "vx00";
		subject.InterchangeNoteCode = "82B";
		//Test Parameters
		subject.InterchangeAcknowledgmentCode = interchangeAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("82B", true)]
	public void Validation_RequiredInterchangeNoteCode(string interchangeNoteCode, bool isValidExpected)
	{
		var subject = new TA1_InterchangeAcknowledgment();
		//Required fields
		subject.InterchangeControlNumber = 233194512;
		subject.InterchangeDate = "zEvEeJ";
		subject.InterchangeTime = "vx00";
		subject.InterchangeAcknowledgmentCode = "m";
		//Test Parameters
		subject.InterchangeNoteCode = interchangeNoteCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
