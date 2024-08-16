using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D04B;
using Eddy.Edifact.Models.D04B.Composites;

namespace Eddy.Edifact.Tests.Models.D04B.Composites;

public class E996Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "u:z:s:3:T:N:P";

		var expected = new E996_ProductClassDetails()
		{
			CharacteristicDescriptionCode = "u",
			RequestedInformationDescription = "z",
			SpecialServiceDescriptionCode = "s",
			ItemDescriptionCode = "3",
			ItemDescriptionCode2 = "T",
			ItemDescriptionCode3 = "N",
			ProductCharacteristicIdentificationCode = "P",
		};

		var actual = Map.MapComposite<E996_ProductClassDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
