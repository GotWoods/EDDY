using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E778Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:2";

		var expected = new E778_PositionIdentification()
		{
			HierarchicalIdNumber = "M",
			SequenceNumber = "2",
		};

		var actual = Map.MapComposite<E778_PositionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
