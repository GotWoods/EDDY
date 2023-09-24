using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class MSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSG*J*si";

		var expected = new MSG_MessageText()
		{
			FreeFormMessageText = "J",
			PrinterCarriageControlCode = "si",
		};

		var actual = Map.MapObject<MSG_MessageText>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredFreeFormMessageText(string freeFormMessageText, bool isValidExpected)
	{
		var subject = new MSG_MessageText();
		subject.FreeFormMessageText = freeFormMessageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
