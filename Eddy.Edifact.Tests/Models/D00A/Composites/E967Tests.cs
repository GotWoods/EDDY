using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E967Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:l:M:A";

		var expected = new E967_ConsumerReferenceIdentification()
		{
			ReferenceFunctionCodeQualifier = "h",
			ReferenceIdentifier = "l",
			PartyName = "M",
			TravellerReferenceIdentifier = "A",
		};

		var actual = Map.MapComposite<E967_ConsumerReferenceIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceFunctionCodeQualifier(string referenceFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E967_ConsumerReferenceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceFunctionCodeQualifier = referenceFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
