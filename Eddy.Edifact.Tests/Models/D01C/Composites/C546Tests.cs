using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C546Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:u";

		var expected = new C546_IndexValue()
		{
			IndexText = "o",
			IndexRepresentationCode = "u",
		};

		var actual = Map.MapComposite<C546_IndexValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredIndexText(string indexText, bool isValidExpected)
	{
		var subject = new C546_IndexValue();
		//Required fields
		//Test Parameters
		subject.IndexText = indexText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
