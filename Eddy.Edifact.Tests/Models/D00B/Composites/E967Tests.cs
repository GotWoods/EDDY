using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E967Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:L:p:1";

		var expected = new E967_ConsumerReferenceIdentification()
		{
			ReferenceCodeQualifier = "o",
			ReferenceIdentifier = "L",
			PartyName = "p",
			TravellerReferenceIdentifier = "1",
		};

		var actual = Map.MapComposite<E967_ConsumerReferenceIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceCodeQualifier(string referenceCodeQualifier, bool isValidExpected)
	{
		var subject = new E967_ConsumerReferenceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
