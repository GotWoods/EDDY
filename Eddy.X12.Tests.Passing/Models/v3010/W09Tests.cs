using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W09*hi*6*p7*3*BA*l";

		var expected = new W09_EquipmentAndTemperature()
		{
			EquipmentDescriptionCode = "hi",
			Temperature = 6,
			UnitOfMeasurementCode = "p7",
			Temperature2 = 3,
			UnitOfMeasurementCode2 = "BA",
			FreeFormMessage = "l",
		};

		var actual = Map.MapObject<W09_EquipmentAndTemperature>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hi", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W09_EquipmentAndTemperature();
		//Required fields
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
