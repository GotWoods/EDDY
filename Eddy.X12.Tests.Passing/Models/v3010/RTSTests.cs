using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RTS*5*5*1*3*4*1*5*4*4*2*8*1*9*3*2*1";

		var expected = new RTS_TariffRates()
		{
			FreightRate = 5,
			FreightRate2 = 5,
			FreightRate3 = 1,
			FreightRate4 = 3,
			FreightRate5 = 4,
			FreightRate6 = 1,
			FreightRate7 = 5,
			FreightRate8 = 4,
			FreightRate9 = 4,
			FreightRate10 = 2,
			FreightRate11 = 8,
			FreightRate12 = 1,
			FreightRate13 = 9,
			FreightRate14 = 3,
			FreightRate15 = 2,
			FreightRate16 = 1,
		};

		var actual = Map.MapObject<RTS_TariffRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
