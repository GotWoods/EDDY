using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D09A;
using Eddy.Edifact.Models.D09A.Composites;

namespace Eddy.Edifact.Tests.Models.D09A;

public class GIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GID+2+++++";

		var expected = new GID_GoodsItemDetails()
		{
			GoodsItemNumber = "2",
			NumberAndTypeOfPackages = null,
			NumberAndTypeOfPackages2 = null,
			NumberAndTypeOfPackages3 = null,
			NumberAndTypeOfPackages4 = null,
			NumberAndTypeOfPackages5 = null,
		};

		var actual = Map.MapObject<GID_GoodsItemDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
