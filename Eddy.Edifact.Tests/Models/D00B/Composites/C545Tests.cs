using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C545Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "5:e:L:1";

		var expected = new C545_IndexIdentification()
		{
			IndexCodeQualifier = "5",
			IndexTypeIdentifier = "e",
			CodeListIdentificationCode = "L",
			CodeListResponsibleAgencyCode = "1",
		};

		var actual = Map.MapComposite<C545_IndexIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredIndexCodeQualifier(string indexCodeQualifier, bool isValidExpected)
	{
		var subject = new C545_IndexIdentification();
		//Required fields
		//Test Parameters
		subject.IndexCodeQualifier = indexCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
