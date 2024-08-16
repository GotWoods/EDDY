using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C545Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:w:H:P";

		var expected = new C545_IndexIdentification()
		{
			IndexQualifier = "U",
			IndexTypeCoded = "w",
			CodeListQualifier = "H",
			CodeListResponsibleAgencyCoded = "P",
		};

		var actual = Map.MapComposite<C545_IndexIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredIndexQualifier(string indexQualifier, bool isValidExpected)
	{
		var subject = new C545_IndexIdentification();
		//Required fields
		//Test Parameters
		subject.IndexQualifier = indexQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
