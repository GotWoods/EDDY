using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS2*xF*7*cd*6";

		var expected = new MS2_EquipmentOrContainerOwnerAndType()
		{
			StandardCarrierAlphaCode = "xF",
			EquipmentNumber = "7",
			EquipmentDescriptionCode = "cd",
			EquipmentNumberCheckDigit = 6,
		};

		var actual = Map.MapObject<MS2_EquipmentOrContainerOwnerAndType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xF", "7", true)]
	[InlineData("xF", "", false)]
	[InlineData("", "7", false)]
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
	[InlineData(6, "7", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "7", true)]
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
			subject.StandardCarrierAlphaCode = "xF";
			subject.EquipmentNumber = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
