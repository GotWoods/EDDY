using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E778Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "m:L";

		var expected = new E778_PositionIdentification()
		{
			HierarchicalStructureLevelIdentifier = "m",
			SequenceNumber = "L",
		};

		var actual = Map.MapComposite<E778_PositionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
