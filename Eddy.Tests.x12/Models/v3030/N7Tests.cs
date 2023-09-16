using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class N7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7*K*R*7*M*776*58*3*1*f*S*uo*R*ZL6*R*2919*h*O*8*LZ*3*6*enIL*GG";

		var expected = new N7_EquipmentDetails()
		{
			EquipmentInitial = "K",
			EquipmentNumber = "R",
			Weight = 7,
			WeightQualifier = "M",
			TareWeight = 776,
			WeightAllowance = 58,
			Dunnage = 3,
			Volume = 1,
			VolumeUnitQualifier = "f",
			OwnershipCode = "S",
			EquipmentDescriptionCode = "uo",
			EquipmentOwnerCode = "R",
			TemperatureControl = "ZL6",
			Position = "R",
			EquipmentLength = 2919,
			TareQualifierCode = "h",
			WeightUnitCode = "O",
			EquipmentNumberCheckDigit = 8,
			TypeOfServiceCode = "LZ",
			Height = 3,
			Width = 6,
			EquipmentType = "enIL",
			StandardCarrierAlphaCode = "GG",
		};

		var actual = Map.MapObject<N7_EquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 776;
			subject.TareQualifierCode = "h";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 1;
			subject.VolumeUnitQualifier = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "M", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "M", true)]
	public void Validation_ARequiresBWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "R";
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 776;
			subject.TareQualifierCode = "h";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 1;
			subject.VolumeUnitQualifier = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(776, "h", true)]
	[InlineData(776, "", false)]
	[InlineData(0, "h", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "R";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 1;
			subject.VolumeUnitQualifier = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "f", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "f", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "R";
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 776;
			subject.TareQualifierCode = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
