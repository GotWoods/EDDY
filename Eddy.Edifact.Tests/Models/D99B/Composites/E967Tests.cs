using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E967Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:U:o:v";

		var expected = new E967_ConsumerReferenceIdentification()
		{
			ReferenceFunctionCodeQualifier = "2",
			ReferenceIdentifier = "U",
			PartyName = "o",
			TravellerReferenceNumber = "v",
		};

		var actual = Map.MapComposite<E967_ConsumerReferenceIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceFunctionCodeQualifier(string referenceFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E967_ConsumerReferenceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceFunctionCodeQualifier = referenceFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
