using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSG*d*0n*3";

		var expected = new MSG_MessageText()
		{
			FreeFormMessageText = "d",
			PrinterCarriageControlCode = "0n",
			Number = 3,
		};

		var actual = Map.MapObject<MSG_MessageText>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredFreeFormMessageText(string freeFormMessageText, bool isValidExpected)
	{
		var subject = new MSG_MessageText();
		subject.FreeFormMessageText = freeFormMessageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "0n", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "0n", true)]
	public void Validation_ARequiresBNumber(int number, string printerCarriageControlCode, bool isValidExpected)
	{
		var subject = new MSG_MessageText();
		subject.FreeFormMessageText = "d";
		if (number > 0)
			subject.Number = number;
		subject.PrinterCarriageControlCode = printerCarriageControlCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
