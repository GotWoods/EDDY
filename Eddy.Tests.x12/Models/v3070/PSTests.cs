using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PS*w9S*M*y3*4*yk*D*jO*2P*1*w*p*3*9*3";

		var expected = new PS_ProtectiveServiceInstructions()
		{
			ProtectiveServiceRuleCode = "w9S",
			ProtectiveServiceCode = "M",
			UnitOrBasisForMeasurementCode = "y3",
			Temperature = 4,
			StandardCarrierAlphaCode = "yk",
			FreightStationAccountingCode = "D",
			CityName = "jO",
			StateOrProvinceCode = "2P",
			Weight = 1,
			PreCooledRule710Code = "w",
			YesNoConditionOrResponseCode = "p",
			YesNoConditionOrResponseCode2 = "3",
			YesNoConditionOrResponseCode3 = "9",
			Temperature2 = 3,
		};

		var actual = Map.MapObject<PS_ProtectiveServiceInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w9S", true)]
	public void Validation_RequiredProtectiveServiceRuleCode(string protectiveServiceRuleCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceCode = "M";
		//Test Parameters
		subject.ProtectiveServiceRuleCode = protectiveServiceRuleCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0 || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "y3";
			subject.Temperature = 4;
			subject.Temperature2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredProtectiveServiceCode(string protectiveServiceCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "w9S";
		//Test Parameters
		subject.ProtectiveServiceCode = protectiveServiceCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0 || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "y3";
			subject.Temperature = 4;
			subject.Temperature2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("y3", 4, 3, true)]
	[InlineData("y3", 0, 0, false)]
	[InlineData("", 4, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, decimal temperature2, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "w9S";
		subject.ProtectiveServiceCode = "M";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0) 
			subject.Temperature = temperature;
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
