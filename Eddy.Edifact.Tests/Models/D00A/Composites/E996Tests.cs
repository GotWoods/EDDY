using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E996Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:O:O:o:0:B";

		var expected = new E996_ProductClassDetails()
		{
			CharacteristicDescriptionCode = "6",
			RequestedInformationDescription = "O",
			SpecialServiceDescriptionCode = "O",
			ItemDescriptionCode = "o",
			ItemDescriptionCode2 = "0",
			ItemDescriptionCode3 = "B",
		};

		var actual = Map.MapComposite<E996_ProductClassDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
