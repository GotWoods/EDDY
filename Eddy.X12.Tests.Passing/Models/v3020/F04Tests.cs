using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class F04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F04*6*i*H*9*r*g*7*c*8*U";

		var expected = new F04_WeightVolumeLoss()
		{
			Weight = 6,
			WeightUnitQualifier = "i",
			WeightQualifier = "H",
			Weight2 = 9,
			WeightUnitQualifier2 = "r",
			WeightQualifier2 = "g",
			Volume = 7,
			VolumeUnitQualifier = "c",
			Volume2 = 8,
			VolumeUnitQualifier2 = "U",
		};

		var actual = Map.MapObject<F04_WeightVolumeLoss>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", 0, "", 0, 0, true)]
	[InlineData(6, "i", 6, "H", 6, 9, true)]
	[InlineData(6, "", 0, "", 0, 0, false)]
	[InlineData(0, "i", 6, "H", 6, 9, true)]
	public void Validation_ARequiresBWeight(decimal weight, string weightUnitQualifier, decimal weigh2t, string weightQualifier, decimal weight3, decimal weight2, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightUnitQualifier = weightUnitQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		if (weight2 > 0) 
			subject.Weight2 = weight2;
		//A Requires B
		if (weight2 > 0)
{
			subject.WeightUnitQualifier2 = "r";
			subject.WeightQualifier2 = "g";
}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", 0, "", true)]
	[InlineData(9, "r", 9, "g", true)]
	[InlineData(9, "", 0, "", false)]
	[InlineData(0, "r", 9, "g", true)]
	public void Validation_ARequiresBWeight2(decimal weight2, string weightUnitQualifier2, decimal weight3, string weightQualifier2, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (weight2 > 0) 
			subject.Weight2 = weight2;
		subject.WeightUnitQualifier2 = weightUnitQualifier2;
		if (weight2 > 0) 
			subject.Weight2 = weight2;
		subject.WeightQualifier2 = weightQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", 0, 0, true)]
	[InlineData(7, "c", 7, 8, true)]
	[InlineData(7, "", 0, 0, false)]
	[InlineData(0, "c", 7, 8, true)]
	public void Validation_ARequiresBVolume(decimal volume, string volumeUnitQualifier, decimal volume2, decimal volume3, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		if (volume2 > 0) 
			subject.Volume2 = volume2;
		//A Requires B
		if (volume3 > 0)
			subject.VolumeUnitQualifier2 = "U";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "U", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "U", true)]
	public void Validation_ARequiresBVolume2(decimal volume2, string volumeUnitQualifier2, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (volume2 > 0) 
			subject.Volume2 = volume2;
		subject.VolumeUnitQualifier2 = volumeUnitQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
