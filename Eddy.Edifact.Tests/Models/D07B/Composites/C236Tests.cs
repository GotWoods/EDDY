using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D07B;
using Eddy.Edifact.Models.D07B.Composites;

namespace Eddy.Edifact.Tests.Models.D07B.Composites;

public class C236Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:1:l:o";

		var expected = new C236_DangerousGoodsLabel()
		{
			DangerousGoodsMarkingIdentifier = "y",
			DangerousGoodsMarkingIdentifier2 = "1",
			DangerousGoodsMarkingIdentifier3 = "l",
			DangerousGoodsMarkingIdentifier4 = "o",
		};

		var actual = Map.MapComposite<C236_DangerousGoodsLabel>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
