using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "1:9:T:F:J";

		var expected = new E506_Reference()
		{
			ReferenceCodeQualifier = "1",
			ReferenceIdentifier = "9",
			DocumentLineIdentifier = "T",
			ReferenceVersionIdentifier = "F",
			PartyName = "J",
		};

		var actual = Map.MapComposite<E506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceCodeQualifier(string referenceCodeQualifier, bool isValidExpected)
	{
		var subject = new E506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
