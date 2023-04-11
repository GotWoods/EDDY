using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HLHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HLH**8*6*3*A*y*x";

		var expected = new HLH_HealthInformation()
		{
			MemberHealthAndTreatmentInformation = null,
			Height = 8,
			Weight = 6,
			Weight2 = 3,
			Description = "A",
			CurrentHealthConditionCode = "y",
			Description2 = "x",
		};

		var actual = Map.MapObject<HLH_HealthInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
