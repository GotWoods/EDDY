using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C108Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "q:f:o:p:O";

		var expected = new C108_TextLiteral()
		{
			FreeText = "q",
			FreeText2 = "f",
			FreeText3 = "o",
			FreeText4 = "p",
			FreeText5 = "O",
		};

		var actual = Map.MapComposite<C108_TextLiteral>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredFreeText(string freeText, bool isValidExpected)
	{
		var subject = new C108_TextLiteral();
		//Required fields
		//Test Parameters
		subject.FreeText = freeText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
