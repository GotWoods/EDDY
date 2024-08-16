using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class C778Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:z";

		var expected = new C778_PositionIdentification()
		{
			HierarchicalIdNumber = "L",
			SequenceNumber = "z",
		};

		var actual = Map.MapComposite<C778_PositionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
