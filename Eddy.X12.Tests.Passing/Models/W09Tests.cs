using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W09*oy*8*sZ*4*00*6*P*5*7";

		var expected = new W09_EquipmentAndTemperature()
		{
			EquipmentDescriptionCode = "oy",
			Temperature = 8,
			UnitOrBasisForMeasurementCode = "sZ",
			Temperature2 = 4,
			UnitOrBasisForMeasurementCode2 = "00",
			FreeFormMessage = "6",
			VentSettingCode = "P",
			PercentIntegerFormat = 5,
			Quantity = 7,
		};

		var actual = Map.MapObject<W09_EquipmentAndTemperature>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oy", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "sZ", true)]
	[InlineData(0, "sZ", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		subject.EquipmentDescriptionCode = "oy";
		if (temperature > 0)
		subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "00", true)]
	[InlineData(0, "00", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		subject.EquipmentDescriptionCode = "oy";
		if (temperature2 > 0)
		subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
