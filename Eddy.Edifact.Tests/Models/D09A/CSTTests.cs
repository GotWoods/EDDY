using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D09A;
using Eddy.Edifact.Models.D09A.Composites;

namespace Eddy.Edifact.Tests.Models.D09A;

public class CSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CST+i+++++";

		var expected = new CST_CustomsStatusOfGoods()
		{
			GoodsItemNumber = "i",
			CustomsIdentityCodes = null,
			CustomsIdentityCodes2 = null,
			CustomsIdentityCodes3 = null,
			CustomsIdentityCodes4 = null,
			CustomsIdentityCodes5 = null,
		};

		var actual = Map.MapObject<CST_CustomsStatusOfGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
