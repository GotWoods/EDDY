using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CMC*t*UG";

		var expected = new CMC_CommodityClassification()
		{
			CommodityCode = "t",
			FreightClassCode = "UG",
		};

		var actual = Map.MapObject<CMC_CommodityClassification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
