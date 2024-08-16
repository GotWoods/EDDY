using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CST+l+++++";

		var expected = new CST_CustomsStatusOfGoods()
		{
			GoodsItemNumber = "l",
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
