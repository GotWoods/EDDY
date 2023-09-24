using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*d*1*W*c*2*M*h*9*c*8*K*4m";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "d",
			CommunicationNumber = "1",
			PackingGroupCode = "W",
			SubsidiaryClassificationCode = "c",
			SubsidiaryClassificationCode2 = "2",
			SubsidiaryClassificationCode3 = "M",
			SubsidiaryRiskIndicatorCode = "h",
			NetExplosiveQuantity = 9,
			CanadianHazardousNotation = "c",
			SpecialCommodityIndicatorCode = "8",
			CommunicationNumber2 = "K",
			UnitOrBasisForMeasurementCode = "4m",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "1", true)]
	[InlineData("d", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredEmergencyResponsePlanNumber(string emergencyResponsePlanNumber, string communicationNumber, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		subject.EmergencyResponsePlanNumber = emergencyResponsePlanNumber;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(subject.NetExplosiveQuantity > 0 || subject.NetExplosiveQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NetExplosiveQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "4m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "4m", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "4m", false)]
	public void Validation_AllAreRequiredNetExplosiveQuantity(int netExplosiveQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.EmergencyResponsePlanNumber = "d";
			subject.CommunicationNumber = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
