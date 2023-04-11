using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MTX*mQk*d*1*sC*2*Jy";

		var expected = new MTX_Text()
		{
			NoteReferenceCode = "mQk",
			TextualData = "d",
			TextualData2 = "1",
			PrinterCarriageControlCode = "sC",
			Number = 2,
			LanguageCode = "Jy",
		};

		var actual = Map.MapObject<MTX_Text>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "d", true)]
	[InlineData("mQk", "", false)]
	public void Validation_ARequiresBNoteReferenceCode(string noteReferenceCode, string textualData, bool isValidExpected)
	{
		var subject = new MTX_Text();
		subject.NoteReferenceCode = noteReferenceCode;
		subject.TextualData = textualData;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "d", true)]
	[InlineData("1", "", false)]
	public void Validation_ARequiresBTextualData2(string textualData2, string textualData, bool isValidExpected)
	{
		var subject = new MTX_Text();
		subject.TextualData2 = textualData2;
		subject.TextualData = textualData;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "sC", true)]
	[InlineData(2, "", false)]
	public void Validation_ARequiresBNumber(int number, string printerCarriageControlCode, bool isValidExpected)
	{
		var subject = new MTX_Text();
		if (number > 0)
		subject.Number = number;
		subject.PrinterCarriageControlCode = printerCarriageControlCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
