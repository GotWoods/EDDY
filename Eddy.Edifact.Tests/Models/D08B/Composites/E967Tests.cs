using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E967Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:w:G:u";

		var expected = new E967_ConsumerReferenceIdentification()
		{
			ReferenceCodeQualifier = "9",
			ReferenceIdentifier = "w",
			PartyName = "G",
			TravellerReferenceIdentifier = "u",
		};

		var actual = Map.MapComposite<E967_ConsumerReferenceIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredReferenceCodeQualifier(string referenceCodeQualifier, bool isValidExpected)
	{
		var subject = new E967_ConsumerReferenceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
