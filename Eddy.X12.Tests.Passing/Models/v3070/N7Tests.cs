using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class N7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7*S*Z*6*s*428*99*9*5*2*W*CG*9Y*wYT*8*8691*m*f*1*FT*7*9*WGBv*fN*i";

		var expected = new N7_EquipmentDetails()
		{
			EquipmentInitial = "S",
			EquipmentNumber = "Z",
			Weight = 6,
			WeightQualifier = "s",
			TareWeight = 428,
			WeightAllowance = 99,
			Dunnage = 9,
			Volume = 5,
			VolumeUnitQualifier = "2",
			OwnershipCode = "W",
			EquipmentDescriptionCode = "CG",
			StandardCarrierAlphaCode = "9Y",
			TemperatureControl = "wYT",
			Position = "8",
			EquipmentLength = 8691,
			TareQualifierCode = "m",
			WeightUnitCode = "f",
			EquipmentNumberCheckDigit = 1,
			TypeOfServiceCode = "FT",
			Height = 7,
			Width = 9,
			EquipmentType = "WGBv",
			StandardCarrierAlphaCode2 = "fN",
			CarTypeCode = "i",
		};

		var actual = Map.MapObject<N7_EquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 6;
			subject.WeightQualifier = "s";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 428;
			subject.TareQualifierCode = "m";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "s", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "s", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "Z";
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 428;
			subject.TareQualifierCode = "m";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(428, "m", true)]
	[InlineData(428, "", false)]
	[InlineData(0, "m", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "Z";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 6;
			subject.WeightQualifier = "s";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "2", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "2", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "Z";
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 6;
			subject.WeightQualifier = "s";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 428;
			subject.TareQualifierCode = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
