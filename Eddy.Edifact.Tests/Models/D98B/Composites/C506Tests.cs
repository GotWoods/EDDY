using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "p:Z:F:G:K";

		var expected = new C506_Reference()
		{
			ReferenceQualifier = "p",
			ReferenceNumber = "Z",
			LineNumber = "F",
			ReferenceVersionNumber = "G",
			RevisionNumber = "K",
		};

		var actual = Map.MapComposite<C506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceQualifier(string referenceQualifier, bool isValidExpected)
	{
		var subject = new C506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceQualifier = referenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
