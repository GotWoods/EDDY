using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "q:t:V:k:T";

		var expected = new C506_Reference()
		{
			ReferenceFunctionCodeQualifier = "q",
			ReferenceIdentifier = "t",
			DocumentLineIdentifier = "V",
			ReferenceVersionIdentifier = "k",
			RevisionIdentifier = "T",
		};

		var actual = Map.MapComposite<C506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceFunctionCodeQualifier(string referenceFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new C506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceFunctionCodeQualifier = referenceFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
