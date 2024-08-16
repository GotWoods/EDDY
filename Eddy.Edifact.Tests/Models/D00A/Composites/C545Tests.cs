using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C545Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:Q:M:d";

		var expected = new C545_IndexIdentification()
		{
			IndexCodeQualifier = "v",
			IndexTypeIdentifier = "Q",
			CodeListIdentificationCode = "M",
			CodeListResponsibleAgencyCode = "d",
		};

		var actual = Map.MapComposite<C545_IndexIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredIndexCodeQualifier(string indexCodeQualifier, bool isValidExpected)
	{
		var subject = new C545_IndexIdentification();
		//Required fields
		//Test Parameters
		subject.IndexCodeQualifier = indexCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
