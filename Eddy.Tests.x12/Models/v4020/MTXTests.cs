using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class MTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MTX*1mh*8*E*gu*2*vI";

		var expected = new MTX_Text()
		{
			NoteReferenceCode = "1mh",
			MessageText = "8",
			MessageText2 = "E",
			PrinterCarriageControlCode = "gu",
			Number = 2,
			LanguageCode = "vI",
		};

		var actual = Map.MapObject<MTX_Text>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1mh", "8", true)]
	[InlineData("1mh", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBNoteReferenceCode(string noteReferenceCode, string messageText, bool isValidExpected)
	{
		var subject = new MTX_Text();
		//Required fields
		//Test Parameters
		subject.NoteReferenceCode = noteReferenceCode;
		subject.MessageText = messageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "8", true)]
	[InlineData("E", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBMessageText2(string messageText2, string messageText, bool isValidExpected)
	{
		var subject = new MTX_Text();
		//Required fields
		//Test Parameters
		subject.MessageText2 = messageText2;
		subject.MessageText = messageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "gu", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "gu", true)]
	public void Validation_ARequiresBNumber(int number, string printerCarriageControlCode, bool isValidExpected)
	{
		var subject = new MTX_Text();
		//Required fields
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		subject.PrinterCarriageControlCode = printerCarriageControlCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
