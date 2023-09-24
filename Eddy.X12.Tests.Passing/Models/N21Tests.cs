using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N21*T*I*8*9*F*312*J*3*8*7*Zq*i*6947*4*5*67*cBB4*0*fU*4*M";

		var expected = new N21_EquipmentRegistrationDetails()
		{
			EquipmentInitial = "T",
			EquipmentNumber = "I",
			EquipmentNumber2 = "8",
			Weight = 9,
			WeightUnitCode = "F",
			TareWeight = 312,
			WeightUnitCode2 = "J",
			TareQualifierCode = "3",
			Volume = 8,
			VolumeUnitQualifier = "7",
			EquipmentDescriptionCode = "Zq",
			OwnershipCode = "i",
			EquipmentLength = 6947,
			Height = 4,
			Width = 5,
			StandardCarrierAlphaCode = "67",
			EquipmentTypeCode = "cBB4",
			CarTypeCode = "0",
			StandardCarrierAlphaCode2 = "fU",
			EquipmentNumberCheckDigit = 4,
			LocationOnEquipmentCode = "M",
		};

		var actual = Map.MapObject<N21_EquipmentRegistrationDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		subject.EquipmentNumber = "I";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "F", true)]
	[InlineData(0, "F", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "I";
		if (weight > 0)
		subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(312, "J", true)]
	[InlineData(0, "J", false)]
	[InlineData(312, "", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string weightUnitCode2, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "I";
		if (tareWeight > 0)
		subject.TareWeight = tareWeight;
		subject.WeightUnitCode2 = weightUnitCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "7", true)]
	[InlineData(0, "7", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "I";
		if (volume > 0)
		subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
