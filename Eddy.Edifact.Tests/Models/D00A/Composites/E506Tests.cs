using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:Q:B:c:d";

		var expected = new E506_Reference()
		{
			ReferenceFunctionCodeQualifier = "E",
			ReferenceIdentifier = "Q",
			DocumentLineIdentifier = "B",
			ReferenceVersionIdentifier = "c",
			PartyName = "d",
		};

		var actual = Map.MapComposite<E506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredReferenceFunctionCodeQualifier(string referenceFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceFunctionCodeQualifier = referenceFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
