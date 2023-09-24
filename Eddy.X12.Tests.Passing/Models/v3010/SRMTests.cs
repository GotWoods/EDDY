using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRM*6*4*1*2*5*7*9*2*6*7*7*8*9*3*7*4";

		var expected = new SRM_ScaleRates()
		{
			FreightRate = 6,
			FreightRate2 = 4,
			FreightRate3 = 1,
			FreightRate4 = 2,
			FreightRate5 = 5,
			FreightRate6 = 7,
			FreightRate7 = 9,
			FreightRate8 = 2,
			FreightRate9 = 6,
			FreightRate10 = 7,
			FreightRate11 = 7,
			FreightRate12 = 8,
			FreightRate13 = 9,
			FreightRate14 = 3,
			FreightRate15 = 7,
			FreightRate16 = 4,
		};

		var actual = Map.MapObject<SRM_ScaleRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
