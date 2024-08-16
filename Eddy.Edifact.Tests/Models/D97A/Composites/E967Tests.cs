using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E967Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "1:e:r:c";

		var expected = new E967_ConsumerReferenceIdentification()
		{
			ReferenceQualifier = "1",
			ReferenceNumber = "e",
			PartyName = "r",
			TravellerReferenceNumber = "c",
		};

		var actual = Map.MapComposite<E967_ConsumerReferenceIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceQualifier(string referenceQualifier, bool isValidExpected)
	{
		var subject = new E967_ConsumerReferenceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceQualifier = referenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
