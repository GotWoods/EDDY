using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E996Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "C:f:t:8:S:6";

		var expected = new E996_ProductClassDetails()
		{
			CharacteristicDescriptionCode = "C",
			RequestedInformationDescription = "f",
			SpecialServiceDescriptionCode = "t",
			ItemDescriptionIdentification = "8",
			ItemDescriptionIdentification2 = "S",
			ItemDescriptionIdentification3 = "6",
		};

		var actual = Map.MapComposite<E996_ProductClassDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
