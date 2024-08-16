using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:d:l:8:Y";

		var expected = new C506_Reference()
		{
			ReferenceCodeQualifier = "6",
			ReferenceIdentifier = "d",
			DocumentLineIdentifier = "l",
			VersionIdentifier = "8",
			RevisionIdentifier = "Y",
		};

		var actual = Map.MapComposite<C506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceCodeQualifier(string referenceCodeQualifier, bool isValidExpected)
	{
		var subject = new C506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
