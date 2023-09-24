using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W09*U7*7*B4*8*se*m*k*2*9";

		var expected = new W09_EquipmentAndTemperature()
		{
			EquipmentDescriptionCode = "U7",
			Temperature = 7,
			UnitOrBasisForMeasurementCode = "B4",
			Temperature2 = 8,
			UnitOrBasisForMeasurementCode2 = "se",
			FreeFormMessage = "m",
			VentSettingCode = "k",
			Percent = 2,
			Quantity = 9,
		};

		var actual = Map.MapObject<W09_EquipmentAndTemperature>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U7", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Temperature = 7;
			subject.UnitOrBasisForMeasurementCode = "B4";
		}
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Temperature2 = 8;
			subject.UnitOrBasisForMeasurementCode2 = "se";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "B4", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "B4", false)]
	public void Validation_AllAreRequiredTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "U7";
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Temperature2 = 8;
			subject.UnitOrBasisForMeasurementCode2 = "se";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "se", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "se", false)]
	public void Validation_AllAreRequiredTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "U7";
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Temperature = 7;
			subject.UnitOrBasisForMeasurementCode = "B4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
