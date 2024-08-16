using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E981Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:G:q:G:a:4:i:Y:Z";

		var expected = new E981_SpecialRequirementDetails()
		{
			SpecialRequirementDescription = "2",
			MeasurementUnitCode = "G",
			Quantity = "q",
			TravellerReferenceIdentifier = "G",
			CharacteristicValueDescriptionCode = "a",
			CharacteristicValueDescriptionCode2 = "4",
			CharacteristicValueDescriptionCode3 = "i",
			CharacteristicValueDescriptionCode4 = "Y",
			CharacteristicValueDescriptionCode5 = "Z",
		};

		var actual = Map.MapComposite<E981_SpecialRequirementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
