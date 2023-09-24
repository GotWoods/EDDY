using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*m*h*l*6*p*4*1*6*T*O*2*hX";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "m",
			CommunicationNumber = "h",
			PackingGroupCode = "l",
			SubsidiaryClassification = "6",
			SubsidiaryClassification2 = "p",
			SubsidiaryClassification3 = "4",
			SubsidiaryRiskIndicator = "1",
			NetExplosiveQuantity = 6,
			CanadianHazardousNotation = "T",
			SpecialCommodityIndicatorCode = "O",
			CommunicationNumber2 = "2",
			UnitOrBasisForMeasurementCode = "hX",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "hX", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "hX", false)]
	public void Validation_AllAreRequiredNetExplosiveQuantity(int netExplosiveQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
