using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "p:C:v:D:p";

		var expected = new C506_Reference()
		{
			ReferenceCodeQualifier = "p",
			ReferenceIdentifier = "C",
			DocumentLineIdentifier = "v",
			ReferenceVersionIdentifier = "D",
			RevisionIdentifier = "p",
		};

		var actual = Map.MapComposite<C506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceCodeQualifier(string referenceCodeQualifier, bool isValidExpected)
	{
		var subject = new C506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
