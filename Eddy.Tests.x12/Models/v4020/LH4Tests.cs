using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*b*9*Z*v*8*K*O*3*X*c*x*dI";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "b",
			CommunicationNumber = "9",
			PackingGroupCode = "Z",
			SubsidiaryClassification = "v",
			SubsidiaryClassification2 = "8",
			SubsidiaryClassification3 = "K",
			SubsidiaryRiskIndicator = "O",
			NetExplosiveQuantity = 3,
			CanadianHazardousNotation = "X",
			SpecialCommodityIndicatorCode = "c",
			CommunicationNumber2 = "x",
			UnitOrBasisForMeasurementCode = "dI",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "dI", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "dI", false)]
	public void Validation_AllAreRequiredNetExplosiveQuantity(int netExplosiveQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
