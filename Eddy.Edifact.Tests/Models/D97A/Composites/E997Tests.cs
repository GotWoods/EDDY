using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E997Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:q:g:G:Y";

		var expected = new E997_AccommodationAllocationInformation()
		{
			ReferenceNumber = "v",
			RelationshipCoded = "q",
			SpecialRequirementTypeIdentification = "g",
			CharacteristicValueCoded = "G",
			SpecialRequirementDetail = "Y",
		};

		var actual = Map.MapComposite<E997_AccommodationAllocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new E997_AccommodationAllocationInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
