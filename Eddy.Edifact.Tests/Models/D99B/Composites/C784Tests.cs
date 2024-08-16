using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C784Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:Q";

		var expected = new C784_FootnoteIdentification()
		{
			FootnoteIdentifier = "K",
			ObjectIdentificationCodeQualifier = "Q",
		};

		var actual = Map.MapComposite<C784_FootnoteIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredFootnoteIdentifier(string footnoteIdentifier, bool isValidExpected)
	{
		var subject = new C784_FootnoteIdentification();
		//Required fields
		//Test Parameters
		subject.FootnoteIdentifier = footnoteIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
