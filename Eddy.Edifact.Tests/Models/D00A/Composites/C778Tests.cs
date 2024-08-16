using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C778Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:H";

		var expected = new C778_PositionIdentification()
		{
			HierarchicalStructureLevelIdentifier = "M",
			SequencePositionIdentifier = "H",
		};

		var actual = Map.MapComposite<C778_PositionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
