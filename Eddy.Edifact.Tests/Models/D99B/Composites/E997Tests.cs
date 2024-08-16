using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E997Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:d:H:y:W";

		var expected = new E997_AccommodationAllocationInformation()
		{
			ReferenceIdentifier = "o",
			RelationshipDescriptionCode = "d",
			SpecialRequirementTypeIdentification = "H",
			CharacteristicValueCoded = "y",
			SpecialRequirementDetail = "W",
		};

		var actual = Map.MapComposite<E997_AccommodationAllocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceIdentifier(string referenceIdentifier, bool isValidExpected)
	{
		var subject = new E997_AccommodationAllocationInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentifier = referenceIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
