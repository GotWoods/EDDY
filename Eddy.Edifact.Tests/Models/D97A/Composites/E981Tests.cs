using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E981Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:q:Q:0:9:H:j:K:S";

		var expected = new E981_SpecialRequirementDetails()
		{
			SpecialRequirementDetail = "n",
			MeasureUnitQualifier = "q",
			Quantity = "Q",
			TravellerReferenceNumber = "0",
			CharacteristicValueCoded = "9",
			CharacteristicValueCoded2 = "H",
			CharacteristicValueCoded3 = "j",
			CharacteristicValueCoded4 = "K",
			CharacteristicValueCoded5 = "S",
		};

		var actual = Map.MapComposite<E981_SpecialRequirementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
