using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C545Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:f:0:7";

		var expected = new C545_IndexIdentification()
		{
			IndexQualifier = "9",
			IndexTypeCoded = "f",
			CodeListIdentificationCode = "0",
			CodeListResponsibleAgencyCode = "7",
		};

		var actual = Map.MapComposite<C545_IndexIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredIndexQualifier(string indexQualifier, bool isValidExpected)
	{
		var subject = new C545_IndexIdentification();
		//Required fields
		//Test Parameters
		subject.IndexQualifier = indexQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
