using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*d*lLc0hLH*V*R*y*a*4*3*5*2";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "d",
			CommunicationNumber = "lLc0hLH",
			PackingGroupCode = "V",
			SubsidiaryClassification = "R",
			SubsidiaryClassification2 = "y",
			SubsidiaryClassification3 = "a",
			SubsidiaryRiskIndicator = "4",
			NetExplosiveQuantity = 3,
			CanadianHazardousNotation = "5",
			SpecialCommodityIndicatorCode = "2",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
