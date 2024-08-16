using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E989Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:o:F:0:k:s:Y";

		var expected = new E989_ProductIdentificationDetails()
		{
			ProductIdentifier = "6",
			CharacteristicDescriptionCode = "o",
			ProductCharacteristicIdentificationCode = "F",
			ItemDescriptionIdentification = "0",
			ItemDescriptionIdentification2 = "k",
			ItemDescriptionIdentification3 = "s",
			ProductName = "Y",
		};

		var actual = Map.MapComposite<E989_ProductIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
