using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*n6*W*q*dN*wh*2426*2*6*OZfL*I*Sj*n*Ui";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "n6",
			EquipmentInitial = "W",
			EquipmentNumber = "q",
			SealNumber = "dN",
			SealNumber2 = "wh",
			EquipmentLength = 2426,
			Height = 2,
			Width = 6,
			EquipmentType = "OZfL",
			LoadEmptyStatusCode = "I",
			TypeOfServiceCode = "Sj",
			LocationIdentifier = "n",
			StandardCarrierAlphaCode = "Ui",
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n6", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentNumber = "q";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "n6";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
