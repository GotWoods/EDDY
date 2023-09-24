using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*a*8*1*8*p*X*5*8*W*e*c*kU*uG6*9*Zp";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "a",
			CommunicationNumber = "8",
			PackingGroupCode = "1",
			SubsidiaryClassificationCode = "8",
			SubsidiaryClassificationCode2 = "p",
			SubsidiaryClassificationCode3 = "X",
			SubsidiaryRiskIndicatorCode = "5",
			NetExplosiveQuantity = 8,
			CanadianHazardousNotation = "W",
			SpecialCommodityIndicatorCode = "e",
			CommunicationNumber2 = "c",
			UnitOrBasisForMeasurementCode = "kU",
			HazardousMaterialShipmentInformationQualifier = "uG6",
			Quantity = 9,
			UnitOrBasisForMeasurementCode2 = "Zp",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "8", true)]
	[InlineData("a", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredEmergencyResponsePlanNumber(string emergencyResponsePlanNumber, string communicationNumber, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		subject.EmergencyResponsePlanNumber = emergencyResponsePlanNumber;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(subject.NetExplosiveQuantity > 0 || subject.NetExplosiveQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NetExplosiveQuantity = 8;
			subject.UnitOrBasisForMeasurementCode = "kU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "kU", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "kU", false)]
	public void Validation_AllAreRequiredNetExplosiveQuantity(int netExplosiveQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.EmergencyResponsePlanNumber = "a";
			subject.CommunicationNumber = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
