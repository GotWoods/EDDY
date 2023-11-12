using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W09*3U*5*ap*4*iL*T*v*9*2";

		var expected = new W09_EquipmentAndTemperature()
		{
			EquipmentDescriptionCode = "3U",
			Temperature = 5,
			UnitOrBasisForMeasurementCode = "ap",
			Temperature2 = 4,
			UnitOrBasisForMeasurementCode2 = "iL",
			FreeFormMessage = "T",
			VentSettingCode = "v",
			Percent = 9,
			Quantity = 2,
		};

		var actual = Map.MapObject<W09_EquipmentAndTemperature>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3U", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Temperature = 5;
			subject.UnitOrBasisForMeasurementCode = "ap";
		}
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Temperature2 = 4;
			subject.UnitOrBasisForMeasurementCode2 = "iL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "ap", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "ap", false)]
	public void Validation_AllAreRequiredTemperature(int temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "3U";
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Temperature2 = 4;
			subject.UnitOrBasisForMeasurementCode2 = "iL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "iL", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "iL", false)]
	public void Validation_AllAreRequiredTemperature2(int temperature2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "3U";
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Temperature = 5;
			subject.UnitOrBasisForMeasurementCode = "ap";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
