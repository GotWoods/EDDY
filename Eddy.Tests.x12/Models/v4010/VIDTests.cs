using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*kI*x*h*jq*1H*7672*7*7*Qz7E*P*QG*N*6L";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "kI",
			EquipmentInitial = "x",
			EquipmentNumber = "h",
			SealNumber = "jq",
			SealNumber2 = "1H",
			EquipmentLength = 7672,
			Height = 7,
			Width = 7,
			EquipmentType = "Qz7E",
			LoadEmptyStatusCode = "P",
			TypeOfServiceCode = "QG",
			LocationIdentifier = "N",
			StandardCarrierAlphaCode = "6L",
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kI", true)]
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
		subject.EquipmentDescriptionCode = "kI";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
