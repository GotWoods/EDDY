using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PS*bB5*w*tI*8*z7*w*zn*Sw*5*M*o*P*K*1";

		var expected = new PS_ProtectiveServiceInstructions()
		{
			ProtectiveServiceRuleCode = "bB5",
			ProtectiveServiceCode = "w",
			UnitOrBasisForMeasurementCode = "tI",
			Temperature = 8,
			StandardCarrierAlphaCode = "z7",
			FreightStationAccountingCode = "w",
			CityName = "zn",
			StateOrProvinceCode = "Sw",
			Weight = 5,
			PreCooledRule710Code = "M",
			YesNoConditionOrResponseCode = "o",
			YesNoConditionOrResponseCode2 = "P",
			YesNoConditionOrResponseCode3 = "K",
			Temperature2 = 1,
		};

		var actual = Map.MapObject<PS_ProtectiveServiceInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bB5", true)]
	public void Validation_RequiredProtectiveServiceRuleCode(string protectiveServiceRuleCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceCode = "w";
		//Test Parameters
		subject.ProtectiveServiceRuleCode = protectiveServiceRuleCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0 || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "tI";
			subject.Temperature = 8;
			subject.Temperature2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredProtectiveServiceCode(string protectiveServiceCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "bB5";
		//Test Parameters
		subject.ProtectiveServiceCode = protectiveServiceCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0 || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "tI";
			subject.Temperature = 8;
			subject.Temperature2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("tI", 8, 1, true)]
	[InlineData("tI", 0, 0, false)]
	[InlineData("", 8, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, decimal temperature2, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "bB5";
		subject.ProtectiveServiceCode = "w";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0) 
			subject.Temperature = temperature;
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		//A Requires B
		if (temperature > 0)
			subject.UnitOrBasisForMeasurementCode = "tI";
		if (temperature2 > 0)
			subject.UnitOrBasisForMeasurementCode = "tI";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "tI", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "tI", true)]
	public void Validation_ARequiresBTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "bB5";
		subject.ProtectiveServiceCode = "w";
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature2 > 0)
		{
			subject.Temperature2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "tI", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "tI", true)]
	public void Validation_ARequiresBTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "bB5";
		subject.ProtectiveServiceCode = "w";
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.Temperature = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
