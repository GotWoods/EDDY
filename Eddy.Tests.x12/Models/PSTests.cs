using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PS*U2o*0*9j*3*bz*A*x1*fX*5*T*v*W*N*1";

		var expected = new PS_ProtectiveServiceInstructions()
		{
			ProtectiveServiceRuleCode = "U2o",
			ProtectiveServiceCode = "0",
			UnitOrBasisForMeasurementCode = "9j",
			Temperature = 3,
			StandardCarrierAlphaCode = "bz",
			FreightStationAccountingCode = "A",
			CityName = "x1",
			StateOrProvinceCode = "fX",
			Weight = 5,
			PreCooledRule710Code = "T",
			YesNoConditionOrResponseCode = "v",
			YesNoConditionOrResponseCode2 = "W",
			YesNoConditionOrResponseCode3 = "N",
			Temperature2 = 1,
		};

		var actual = Map.MapObject<PS_ProtectiveServiceInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U2o", true)]
	public void Validation_RequiredProtectiveServiceRuleCode(string protectiveServiceRuleCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		subject.ProtectiveServiceCode = "0";
		subject.ProtectiveServiceRuleCode = protectiveServiceRuleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredProtectiveServiceCode(string protectiveServiceCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		subject.ProtectiveServiceRuleCode = "U2o";
		subject.ProtectiveServiceCode = protectiveServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("9j", 3, true)]
	[InlineData("",3, true)]
	[InlineData("9j", 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, decimal temperature2, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		subject.ProtectiveServiceRuleCode = "U2o";
		subject.ProtectiveServiceCode = "0";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0)
		subject.Temperature = temperature;
		if (temperature2 > 0)
		subject.Temperature2 = temperature2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "9j", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		subject.ProtectiveServiceRuleCode = "U2o";
		subject.ProtectiveServiceCode = "0";
		if (temperature > 0)
		subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "9j", true)]
	[InlineData(1, "", false)]
	public void Validation_ARequiresBTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		subject.ProtectiveServiceRuleCode = "U2o";
		subject.ProtectiveServiceCode = "0";
		if (temperature2 > 0)
		subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
