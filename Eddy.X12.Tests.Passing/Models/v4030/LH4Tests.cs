using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*I*w*q*e*A*H*V*3*N*y*P*pP";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "I",
			CommunicationNumber = "w",
			PackingGroupCode = "q",
			SubsidiaryClassification = "e",
			SubsidiaryClassification2 = "A",
			SubsidiaryClassification3 = "H",
			SubsidiaryRiskIndicator = "V",
			NetExplosiveQuantity = 3,
			CanadianHazardousNotation = "N",
			SpecialCommodityIndicatorCode = "y",
			CommunicationNumber2 = "P",
			UnitOrBasisForMeasurementCode = "pP",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "w", true)]
	[InlineData("I", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredEmergencyResponsePlanNumber(string emergencyResponsePlanNumber, string communicationNumber, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		subject.EmergencyResponsePlanNumber = emergencyResponsePlanNumber;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(subject.NetExplosiveQuantity > 0 || subject.NetExplosiveQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NetExplosiveQuantity = 3;
			subject.UnitOrBasisForMeasurementCode = "pP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "pP", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "pP", false)]
	public void Validation_AllAreRequiredNetExplosiveQuantity(int netExplosiveQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.EmergencyResponsePlanNumber = "I";
			subject.CommunicationNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
