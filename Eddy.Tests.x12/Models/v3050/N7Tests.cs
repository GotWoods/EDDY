using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class N7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7*n*2*8*x*439*81*5*6*C*k*vH*Sm*ZRe*i*1496*J*b*1*xv*5*7*hdUM*Xs*e";

		var expected = new N7_EquipmentDetails()
		{
			EquipmentInitial = "n",
			EquipmentNumber = "2",
			Weight = 8,
			WeightQualifier = "x",
			TareWeight = 439,
			WeightAllowance = 81,
			Dunnage = 5,
			Volume = 6,
			VolumeUnitQualifier = "C",
			OwnershipCode = "k",
			EquipmentDescriptionCode = "vH",
			StandardCarrierAlphaCode = "Sm",
			TemperatureControl = "ZRe",
			Position = "i",
			EquipmentLength = 1496,
			TareQualifierCode = "J",
			WeightUnitCode = "b",
			EquipmentNumberCheckDigit = 1,
			TypeOfServiceCode = "xv",
			Height = 5,
			Width = 7,
			EquipmentType = "hdUM",
			StandardCarrierAlphaCode2 = "Xs",
			CarTypeCode = "e",
		};

		var actual = Map.MapObject<N7_EquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 439;
			subject.TareQualifierCode = "J";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "x", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "2";
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 439;
			subject.TareQualifierCode = "J";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(439, "J", true)]
	[InlineData(439, "", false)]
	[InlineData(0, "J", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "2";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "C", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "C", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = "2";
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 439;
			subject.TareQualifierCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
