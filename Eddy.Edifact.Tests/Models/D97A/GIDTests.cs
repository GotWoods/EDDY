using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class GIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GID+o+++++";

		var expected = new GID_GoodsItemDetails()
		{
			GoodsItemNumber = "o",
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
