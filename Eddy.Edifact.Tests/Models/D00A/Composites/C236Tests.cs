using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C236Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:j:y";

		var expected = new C236_DangerousGoodsLabel()
		{
			DangerousGoodsMarkingIdentifier = "G",
			DangerousGoodsMarkingIdentifier2 = "j",
			DangerousGoodsMarkingIdentifier3 = "y",
		};

		var actual = Map.MapComposite<C236_DangerousGoodsLabel>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
