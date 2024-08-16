using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C784Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:u";

		var expected = new C784_FootnoteIdentification()
		{
			FootnoteIdentifier = "d",
			IdentityNumberQualifier = "u",
		};

		var actual = Map.MapComposite<C784_FootnoteIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredFootnoteIdentifier(string footnoteIdentifier, bool isValidExpected)
	{
		var subject = new C784_FootnoteIdentification();
		//Required fields
		//Test Parameters
		subject.FootnoteIdentifier = footnoteIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
