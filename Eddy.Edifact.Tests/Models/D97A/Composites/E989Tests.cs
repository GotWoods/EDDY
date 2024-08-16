using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E989Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Y:H:O:u:r:g";

		var expected = new E989_ProductIdentificationDetails()
		{
			ProductIdentification = "Y",
			CharacteristicIdentification = "H",
			ProductIdentificationCharacteristicCoded = "O",
			ItemDescriptionIdentification = "u",
			ItemDescriptionIdentification2 = "r",
			ItemDescriptionIdentification3 = "g",
		};

		var actual = Map.MapComposite<E989_ProductIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
