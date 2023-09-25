using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class HLHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HLH**1*4*2*F*8*h";

		var expected = new HLH_HealthInformation()
		{
			MemberHealthAndTreatmentInformation = null,
			Height = 1,
			Weight = 4,
			Weight2 = 2,
			Description = "F",
			CurrentHealthConditionCode = "8",
			Description2 = "h",
		};

		var actual = Map.MapObject<HLH_HealthInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
