using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C778Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:g";

		var expected = new C778_PositionIdentification()
		{
			HierarchicalIdNumber = "E",
			SequenceNumber = "g",
		};

		var actual = Map.MapComposite<C778_PositionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
