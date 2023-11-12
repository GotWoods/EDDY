using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class N21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N21*e*O*G*3*I*766*H*R*4*r*PJ*F*6144*3*5*3w*pO48*T*G6*2*Q";

		var expected = new N21_EquipmentRegistrationDetails()
		{
			EquipmentInitial = "e",
			EquipmentNumber = "O",
			EquipmentNumber2 = "G",
			Weight = 3,
			WeightUnitCode = "I",
			TareWeight = 766,
			WeightUnitCode2 = "H",
			TareQualifierCode = "R",
			Volume = 4,
			VolumeUnitQualifier = "r",
			EquipmentDescriptionCode = "PJ",
			OwnershipCode = "F",
			EquipmentLength = 6144,
			Height = 3,
			Width = 5,
			StandardCarrierAlphaCode = "3w",
			EquipmentTypeCode = "pO48",
			CarTypeCode = "T",
			StandardCarrierAlphaCode2 = "G6",
			EquipmentNumberCheckDigit = 2,
			LocationOnEquipmentCode = "Q",
		};

		var actual = Map.MapObject<N21_EquipmentRegistrationDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		//Required fields
		subject.EquipmentNumber = "O";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 3;
			subject.WeightUnitCode = "I";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.TareWeight = 766;
			subject.WeightUnitCode2 = "H";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		//Required fields
		subject.EquipmentInitial = "e";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 3;
			subject.WeightUnitCode = "I";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.TareWeight = 766;
			subject.WeightUnitCode2 = "H";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "I", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "I", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "O";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.TareWeight = 766;
			subject.WeightUnitCode2 = "H";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(766, "H", true)]
	[InlineData(766, "", false)]
	[InlineData(0, "H", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string weightUnitCode2, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "O";
		//Test Parameters
		if (tareWeight > 0) 
			subject.TareWeight = tareWeight;
		subject.WeightUnitCode2 = weightUnitCode2;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 3;
			subject.WeightUnitCode = "I";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "r", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "r", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new N21_EquipmentRegistrationDetails();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "O";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 3;
			subject.WeightUnitCode = "I";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.TareWeight = 766;
			subject.WeightUnitCode2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
