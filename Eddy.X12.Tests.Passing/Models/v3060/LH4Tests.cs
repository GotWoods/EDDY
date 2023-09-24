using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*s*5*k*v*U*M*v*3*G*4*2";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "s",
			CommunicationNumber = "5",
			PackingGroupCode = "k",
			SubsidiaryClassification = "v",
			SubsidiaryClassification2 = "U",
			SubsidiaryClassification3 = "M",
			SubsidiaryRiskIndicator = "v",
			NetExplosiveQuantity = 3,
			CanadianHazardousNotation = "G",
			SpecialCommodityIndicatorCode = "4",
			CommunicationNumber2 = "2",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
