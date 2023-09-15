using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*e*U*y*j*s*R*9*9*o*j";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "e",
			CommunicationNumber = "U",
			PackingGroupCode = "y",
			SubsidiaryClassification = "j",
			SubsidiaryClassification2 = "s",
			SubsidiaryClassification3 = "R",
			SubsidiaryRiskIndicator = "9",
			NetExplosiveQuantity = 9,
			CanadianHazardousNotation = "o",
			SpecialCommodityIndicatorCode = "j",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
