using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E989Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:H:b:C:q:d:r";

		var expected = new E989_ProductIdentificationDetails()
		{
			ProductIdentification = "5",
			CharacteristicIdentification = "H",
			ProductIdentificationCharacteristicCoded = "b",
			ItemDescriptionIdentification = "C",
			ItemDescriptionIdentification2 = "q",
			ItemDescriptionIdentification3 = "d",
			ProductName = "r",
		};

		var actual = Map.MapComposite<E989_ProductIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
