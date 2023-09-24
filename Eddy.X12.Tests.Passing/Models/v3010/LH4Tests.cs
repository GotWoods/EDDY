using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*s*yCcitm2*g*L*P*y*J*7*G*f";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "s",
			CommunicationNumber = "yCcitm2",
			PackingGroupCode = "g",
			SubsidiaryClassification = "L",
			SubsidiaryClassification2 = "P",
			SubsidiaryClassification3 = "y",
			SubsidiaryRiskIndicator = "J",
			NetExplosiveQuantity = 7,
			CanadianHazardousNotation = "G",
			SpecialCommodityIndicatorCode = "f",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
