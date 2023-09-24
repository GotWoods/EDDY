using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class WGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WGP*6*4*6*9*3*4*8*5*2*1*4*9*9*5*5*5";

		var expected = new WGP_TariffWeightGroup()
		{
			Weight = 6,
			Weight2 = 4,
			Weight3 = 6,
			Weight4 = 9,
			Weight5 = 3,
			Weight6 = 4,
			Weight7 = 8,
			Weight8 = 5,
			Weight9 = 2,
			Weight10 = 1,
			Weight11 = 4,
			Weight12 = 9,
			Weight13 = 9,
			Weight14 = 5,
			Weight15 = 5,
			Weight16 = 5,
		};

		var actual = Map.MapObject<WGP_TariffWeightGroup>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
