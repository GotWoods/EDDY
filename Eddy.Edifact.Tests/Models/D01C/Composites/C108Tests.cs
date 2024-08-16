using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C108Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:d:Q:f:c";

		var expected = new C108_TextLiteral()
		{
			FreeText = "l",
			FreeText2 = "d",
			FreeText3 = "Q",
			FreeText4 = "f",
			FreeText5 = "c",
		};

		var actual = Map.MapComposite<C108_TextLiteral>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredFreeText(string freeText, bool isValidExpected)
	{
		var subject = new C108_TextLiteral();
		//Required fields
		//Test Parameters
		subject.FreeText = freeText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
