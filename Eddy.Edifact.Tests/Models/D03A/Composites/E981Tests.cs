using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E981Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:S:b:j:B:C:m:T:y";

		var expected = new E981_SpecialRequirementDetails()
		{
			SpecialRequirementDescription = "k",
			MeasurementUnitCode = "S",
			Quantity = "b",
			TravellerReferenceIdentifier = "j",
			CharacteristicValueDescriptionCode = "B",
			CharacteristicValueDescriptionCode2 = "C",
			CharacteristicValueDescriptionCode3 = "m",
			CharacteristicValueDescriptionCode4 = "T",
			CharacteristicValueDescriptionCode5 = "y",
		};

		var actual = Map.MapComposite<E981_SpecialRequirementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
