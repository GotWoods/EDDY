using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class MS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS2*sH*x*J1*7";

		var expected = new MS2_EquipmentOrContainerOwnerAndType()
		{
			StandardCarrierAlphaCode = "sH",
			EquipmentNumber = "x",
			EquipmentDescriptionCode = "J1",
			EquipmentNumberCheckDigit = 7,
		};

		var actual = Map.MapObject<MS2_EquipmentOrContainerOwnerAndType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sH", "x", true)]
	[InlineData("sH", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string equipmentNumber, bool isValidExpected)
	{
		var subject = new MS2_EquipmentOrContainerOwnerAndType();
		//Required fields
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "x", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBEquipmentNumberCheckDigit(int equipmentNumberCheckDigit, string equipmentNumber, bool isValidExpected)
	{
		var subject = new MS2_EquipmentOrContainerOwnerAndType();
		//Required fields
		//Test Parameters
		if (equipmentNumberCheckDigit > 0) 
			subject.EquipmentNumberCheckDigit = equipmentNumberCheckDigit;
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.StandardCarrierAlphaCode = "sH";
			subject.EquipmentNumber = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
