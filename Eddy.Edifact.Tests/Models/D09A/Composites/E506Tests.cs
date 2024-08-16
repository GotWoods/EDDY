using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D09A;
using Eddy.Edifact.Models.D09A.Composites;

namespace Eddy.Edifact.Tests.Models.D09A.Composites;

public class E506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:Q:B:6";

		var expected = new E506_Reference()
		{
			ReferenceCodeQualifier = "x",
			ReferenceIdentifier = "Q",
			DocumentLineIdentifier = "B",
			PartyName = "6",
		};

		var actual = Map.MapComposite<E506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceCodeQualifier(string referenceCodeQualifier, bool isValidExpected)
	{
		var subject = new E506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
