using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class HLHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HLH*J*4*7*2*d*7*X";

		var expected = new HLH_HealthInformation()
		{
			HealthRelatedCode = "J",
			Height = 4,
			Weight = 7,
			Weight2 = 2,
			Description = "d",
			CurrentHealthConditionCode = "7",
			Description2 = "X",
		};

		var actual = Map.MapObject<HLH_HealthInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
