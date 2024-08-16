using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C778Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:9";

		var expected = new C778_PositionIdentification()
		{
			HierarchicalStructureLevelIdentifier = "a",
			SequenceNumber = "9",
		};

		var actual = Map.MapComposite<C778_PositionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
