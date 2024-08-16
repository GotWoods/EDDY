using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C108Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:E:K:q:e";

		var expected = new C108_TextLiteral()
		{
			FreeTextValue = "r",
			FreeTextValue2 = "E",
			FreeTextValue3 = "K",
			FreeTextValue4 = "q",
			FreeTextValue5 = "e",
		};

		var actual = Map.MapComposite<C108_TextLiteral>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredFreeTextValue(string freeTextValue, bool isValidExpected)
	{
		var subject = new C108_TextLiteral();
		//Required fields
		//Test Parameters
		subject.FreeTextValue = freeTextValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
