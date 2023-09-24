using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.Tests.Models.v7010;

public class LH4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH4*5*j*s*X*p*d*B*3*i*l*v*TE";

		var expected = new LH4_CanadianDangerousRequirements()
		{
			EmergencyResponsePlanNumber = "5",
			CommunicationNumber = "j",
			PackingGroupCode = "s",
			SubsidiaryClassificationCode = "X",
			SubsidiaryClassificationCode2 = "p",
			SubsidiaryClassificationCode3 = "d",
			SubsidiaryRiskIndicatorCode = "B",
			NetExplosiveQuantity = 3,
			CanadianHazardousNotation = "i",
			SpecialCommodityIndicatorCode = "l",
			CommunicationNumber2 = "v",
			UnitOrBasisForMeasurementCode = "TE",
		};

		var actual = Map.MapObject<LH4_CanadianDangerousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "j", true)]
	[InlineData("5", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredEmergencyResponsePlanNumber(string emergencyResponsePlanNumber, string communicationNumber, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		subject.EmergencyResponsePlanNumber = emergencyResponsePlanNumber;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(subject.NetExplosiveQuantity > 0 || subject.NetExplosiveQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NetExplosiveQuantity = 3;
			subject.UnitOrBasisForMeasurementCode = "TE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "TE", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "TE", false)]
	public void Validation_AllAreRequiredNetExplosiveQuantity(int netExplosiveQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH4_CanadianDangerousRequirements();
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.EmergencyResponsePlanNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.EmergencyResponsePlanNumber = "5";
			subject.CommunicationNumber = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
