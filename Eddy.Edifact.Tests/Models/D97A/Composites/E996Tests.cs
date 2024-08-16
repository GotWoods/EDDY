using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E996Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "V:I:B:8:E:7";

		var expected = new E996_ProductClassDetails()
		{
			CharacteristicIdentification = "V",
			RequestedInformation = "I",
			SpecialServicesCoded = "B",
			ItemDescriptionIdentification = "8",
			ItemDescriptionIdentification2 = "E",
			ItemDescriptionIdentification3 = "7",
		};

		var actual = Map.MapComposite<E996_ProductClassDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
