using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class GIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GID+x+++";

		var expected = new GID_GoodsItemDetails()
		{
			GoodsItemNumber = "x",
			NumberAndTypeOfPackages = null,
			NumberAndTypeOfPackages2 = null,
			NumberAndTypeOfPackages3 = null,
		};

		var actual = Map.MapObject<GID_GoodsItemDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
