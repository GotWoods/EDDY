using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class WGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WGP*1*8*6*9*9*2*2*6*6*5*4*5*1*5*4*1";

		var expected = new WGP_TariffWeightGroup()
		{
			Weight = 1,
			Weight2 = 8,
			Weight3 = 6,
			Weight4 = 9,
			Weight5 = 9,
			Weight6 = 2,
			Weight7 = 2,
			Weight8 = 6,
			Weight9 = 6,
			Weight10 = 5,
			Weight11 = 4,
			Weight12 = 5,
			Weight13 = 1,
			Weight14 = 5,
			Weight15 = 4,
			Weight16 = 1,
		};

		var actual = Map.MapObject<WGP_TariffWeightGroup>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
