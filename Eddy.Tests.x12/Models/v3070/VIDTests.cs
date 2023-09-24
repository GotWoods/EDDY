using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*HC*P*h*Py*sA*4662*8*3*J2kX*t*LK*C";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "HC",
			EquipmentInitial = "P",
			EquipmentNumber = "h",
			SealNumber = "Py",
			SealNumber2 = "sA",
			EquipmentLength = 4662,
			Height = 8,
			Width = 3,
			EquipmentType = "J2kX",
			LoadEmptyStatusCode = "t",
			TypeOfServiceCode = "LK",
			LocationIdentifier = "C",
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HC", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentNumber = "h";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "HC";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
