using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class SRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRM*1*5*8*6*2*2*8*8*6*5*5*3*4*8*5*2";

		var expected = new SRM_ScaleRates()
		{
			FreightRate = 1,
			FreightRate2 = 5,
			FreightRate3 = 8,
			FreightRate4 = 6,
			FreightRate5 = 2,
			FreightRate6 = 2,
			FreightRate7 = 8,
			FreightRate8 = 8,
			FreightRate9 = 6,
			FreightRate10 = 5,
			FreightRate11 = 5,
			FreightRate12 = 3,
			FreightRate13 = 4,
			FreightRate14 = 8,
			FreightRate15 = 5,
			FreightRate16 = 2,
		};

		var actual = Map.MapObject<SRM_ScaleRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
