using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C236Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:U:f";

		var expected = new C236_DangerousGoodsLabel()
		{
			DangerousGoodsLabelMarking = "I",
			DangerousGoodsLabelMarking2 = "U",
			DangerousGoodsLabelMarking3 = "f",
		};

		var actual = Map.MapComposite<C236_DangerousGoodsLabel>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
