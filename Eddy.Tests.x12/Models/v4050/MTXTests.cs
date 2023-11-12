using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class MTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MTX*b57*w*h*Fi*3*rY";

		var expected = new MTX_Text()
		{
			NoteReferenceCode = "b57",
			TextualData = "w",
			TextualData2 = "h",
			PrinterCarriageControlCode = "Fi",
			Number = 3,
			LanguageCode = "rY",
		};

		var actual = Map.MapObject<MTX_Text>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b57", "w", true)]
	[InlineData("b57", "", false)]
	[InlineData("", "w", true)]
	public void Validation_ARequiresBNoteReferenceCode(string noteReferenceCode, string textualData, bool isValidExpected)
	{
		var subject = new MTX_Text();
		//Required fields
		//Test Parameters
		subject.NoteReferenceCode = noteReferenceCode;
		subject.TextualData = textualData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "w", true)]
	[InlineData("h", "", false)]
	[InlineData("", "w", true)]
	public void Validation_ARequiresBTextualData2(string textualData2, string textualData, bool isValidExpected)
	{
		var subject = new MTX_Text();
		//Required fields
		//Test Parameters
		subject.TextualData2 = textualData2;
		subject.TextualData = textualData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Fi", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Fi", true)]
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
