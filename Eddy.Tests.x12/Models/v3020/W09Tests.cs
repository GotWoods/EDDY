using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W09*Hq*9*tp*2*J2*y";

		var expected = new W09_EquipmentAndTemperature()
		{
			EquipmentDescriptionCode = "Hq",
			Temperature = 9,
			UnitOfMeasurementCode = "tp",
			Temperature2 = 2,
			UnitOfMeasurementCode2 = "J2",
			FreeFormMessage = "y",
		};

		var actual = Map.MapObject<W09_EquipmentAndTemperature>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hq", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Temperature = 9;
			subject.UnitOfMeasurementCode = "tp";
		}
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Temperature2 = 2;
			subject.UnitOfMeasurementCode2 = "J2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "tp", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "tp", false)]
	public void Validation_AllAreRequiredTemperature(int temperature, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "Hq";
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Temperature2 = 2;
			subject.UnitOfMeasurementCode2 = "J2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "J2", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "J2", false)]
	public void Validation_AllAreRequiredTemperature2(int temperature2, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		subject.EquipmentDescriptionCode = "Hq";
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Temperature = 9;
			subject.UnitOfMeasurementCode = "tp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
