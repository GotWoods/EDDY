using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*a0*W*I*Lg*bU*5921*2*5*X7Ry";

		var expected = new VID_VehicleID()
		{
			EquipmentDescriptionCode = "a0",
			EquipmentInitial = "W",
			EquipmentNumber = "I",
			SealNumber = "Lg",
			SealNumber2 = "bU",
			EquipmentLength = 5921,
			Height = 2,
			Width = 5,
			EquipmentType = "X7Ry",
		};

		var actual = Map.MapObject<VID_VehicleID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a0", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_VehicleID();
		//Required fields
		subject.EquipmentNumber = "I";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_VehicleID();
		//Required fields
		subject.EquipmentDescriptionCode = "a0";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
