using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C783Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:n";

		var expected = new C783_FootnoteSetIdentification()
		{
			FootnoteSetIdentifier = "T",
			IdentityNumberQualifier = "n",
		};

		var actual = Map.MapComposite<C783_FootnoteSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredFootnoteSetIdentifier(string footnoteSetIdentifier, bool isValidExpected)
	{
		var subject = new C783_FootnoteSetIdentification();
		//Required fields
		//Test Parameters
		subject.FootnoteSetIdentifier = footnoteSetIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
