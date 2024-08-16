using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E981Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:m:1:B:X:k:1:X:k";

		var expected = new E981_SpecialRequirementDetails()
		{
			SpecialRequirementDetail = "q",
			MeasurementUnitCode = "m",
			Quantity = "1",
			TravellerReferenceNumber = "B",
			CharacteristicValueCoded = "X",
			CharacteristicValueCoded2 = "k",
			CharacteristicValueCoded3 = "1",
			CharacteristicValueCoded4 = "X",
			CharacteristicValueCoded5 = "k",
		};

		var actual = Map.MapComposite<E981_SpecialRequirementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
