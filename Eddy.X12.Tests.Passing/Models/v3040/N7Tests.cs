using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class N7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7*0*j*6*i*984*27*5*5*i*9*aZ*D4*6x1*p*6622*2*9*1*qN*3*6*RuES*DU";

		var expected = new N7_EquipmentDetails()
		{
			EquipmentInitial = "0",
			EquipmentNumber = "j",
			Weight = 6,
			WeightQualifier = "i",
			TareWeight = 984,
			WeightAllowance = 27,
			Dunnage = 5,
			Volume = 5,
			VolumeUnitQualifier = "i",
			OwnershipCode = "9",
			EquipmentDescriptionCode = "aZ",
			StandardCarrierAlphaCode = "D4",
			TemperatureControl = "6x1",
			Position = "p",
			EquipmentLength = 6622,
			TareQualifierCode = "2",
			WeightUnitCode = "9",
			EquipmentNumberCheckDigit = 1,
			TypeOfServiceCode = "qN",
			Height = 3,
			Width = 6,
			EquipmentType = "RuES",
			StandardCarrierAlphaCode2 = "DU",
		};

		var actual = Map.MapObject<N7_EquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 984;
			subject.TareQualifierCode = "2";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "i", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "i", true)]
	public void Validation_ARequiresBWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "j";
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 984;
			subject.TareQualifierCode = "2";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(984, "2", true)]
	[InlineData(984, "", false)]
	[InlineData(0, "2", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "j";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "i", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "i", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "j";
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 984;
			subject.TareQualifierCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
