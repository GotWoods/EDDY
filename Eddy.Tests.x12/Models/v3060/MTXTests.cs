using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MTX*ZRf*d*F*nA";

		var expected = new MTX_Text()
		{
			NoteReferenceCode = "ZRf",
			MessageText = "d",
			MessageText2 = "F",
			PrinterCarriageControlCode = "nA",
		};

		var actual = Map.MapObject<MTX_Text>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZRf", "d", true)]
	[InlineData("ZRf", "", false)]
	[InlineData("", "d", true)]
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
	[InlineData("F", "d", true)]
	[InlineData("F", "", false)]
	[InlineData("", "d", true)]
	public void Validation_ARequiresBMessageText2(string messageText2, string messageText, bool isValidExpected)
	{
		var subject = new MTX_Text();
		//Required fields
		//Test Parameters
		subject.MessageText2 = messageText2;
		subject.MessageText = messageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
