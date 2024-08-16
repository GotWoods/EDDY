using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C783Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:A";

		var expected = new C783_FootnoteSetIdentification()
		{
			FootnoteSetIdentifier = "K",
			ObjectIdentificationCodeQualifier = "A",
		};

		var actual = Map.MapComposite<C783_FootnoteSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredFootnoteSetIdentifier(string footnoteSetIdentifier, bool isValidExpected)
	{
		var subject = new C783_FootnoteSetIdentification();
		//Required fields
		//Test Parameters
		subject.FootnoteSetIdentifier = footnoteSetIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
