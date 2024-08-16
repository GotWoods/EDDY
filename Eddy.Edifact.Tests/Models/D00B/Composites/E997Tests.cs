using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E997Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:c:1:Y:t";

		var expected = new E997_AccommodationAllocationInformation()
		{
			ReferenceIdentifier = "n",
			RelationshipDescriptionCode = "c",
			SpecialRequirementTypeCode = "1",
			CharacteristicValueDescriptionCode = "Y",
			SpecialRequirementDescription = "t",
		};

		var actual = Map.MapComposite<E997_AccommodationAllocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredReferenceIdentifier(string referenceIdentifier, bool isValidExpected)
	{
		var subject = new E997_AccommodationAllocationInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentifier = referenceIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
