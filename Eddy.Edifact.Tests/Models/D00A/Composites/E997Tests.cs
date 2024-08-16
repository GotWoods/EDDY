using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E997Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "K:1:D:w:m";

		var expected = new E997_AccommodationAllocationInformation()
		{
			ReferenceIdentifier = "K",
			RelationshipDescriptionCode = "1",
			SpecialRequirementTypeCode = "D",
			CharacteristicValueDescriptionCode = "w",
			SpecialRequirementDescription = "m",
		};

		var actual = Map.MapComposite<E997_AccommodationAllocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredReferenceIdentifier(string referenceIdentifier, bool isValidExpected)
	{
		var subject = new E997_AccommodationAllocationInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentifier = referenceIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
