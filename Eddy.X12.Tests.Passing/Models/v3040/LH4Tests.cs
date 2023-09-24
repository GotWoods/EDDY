using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*a*q*X*l*x*n*V*3*X*T";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "a",
			CommunicationNumber = "q",
			PackingGroupCode = "X",
			SubsidiaryClassification = "l",
			SubsidiaryClassification2 = "x",
			SubsidiaryClassification3 = "n",
			SubsidiaryRiskIndicator = "V",
			NetExplosiveQuantity = 3,
			CanadianHazardousNotation = "X",
			SpecialCommodityIndicatorCode = "T",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
