using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSG*c*KI*1";

		var expected = new MSG_MessageText()
		{
			FreeFormMessageText = "c",
			PrinterCarriageControlCode = "KI",
			Number = 1,
		};

		var actual = Map.MapObject<MSG_MessageText>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredFreeFormMessageText(string freeFormMessageText, bool isValidExpected)
	{
		var subject = new MSG_MessageText();
		subject.FreeFormMessageText = freeFormMessageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "KI", true)]
	[InlineData(1, "", false)]
	public void Validation_ARequiresBNumber(int number, string printerCarriageControlCode, bool isValidExpected)
	{
		var subject = new MSG_MessageText();
		subject.FreeFormMessageText = "c";
		if (number > 0)
		subject.Number = number;
		subject.PrinterCarriageControlCode = printerCarriageControlCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
