using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class W09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W09*wH*3*8v*4*WL*1*R*5*4";

		var expected = new W09_EquipmentAndTemperature()
		{
			EquipmentDescriptionCode = "wH",
			Temperature = 3,
			UnitOrBasisForMeasurementCode = "8v",
			Temperature2 = 4,
			UnitOrBasisForMeasurementCode2 = "WL",
			FreeFormMessage = "1",
			VentSettingCode = "R",
			PercentIntegerFormat = 5,
			Quantity = 4,
		};

		var actual = Map.MapObject<W09_EquipmentAndTemperature>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wH", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Temperature = 3;
			subject.UnitOrBasisForMeasurementCode = "8v";
		}
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Temperature2 = 4;
			subject.UnitOrBasisForMeasurementCode2 = "WL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "8v", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "8v", false)]
	public void Validation_AllAreRequiredTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "wH";
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Temperature2 = 4;
			subject.UnitOrBasisForMeasurementCode2 = "WL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "WL", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "WL", false)]
	public void Validation_AllAreRequiredTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "wH";
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Temperature = 3;
			subject.UnitOrBasisForMeasurementCode = "8v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
