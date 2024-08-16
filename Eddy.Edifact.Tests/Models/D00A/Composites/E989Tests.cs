using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E989Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:D:M:1:p:A:s";

		var expected = new E989_ProductIdentificationDetails()
		{
			ProductIdentifier = "H",
			CharacteristicDescriptionCode = "D",
			ProductCharacteristicIdentificationCode = "M",
			ItemDescriptionCode = "1",
			ItemDescriptionCode2 = "p",
			ItemDescriptionCode3 = "A",
			ProductName = "s",
		};

		var actual = Map.MapComposite<E989_ProductIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
