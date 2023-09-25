using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class F04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F04*1*L*M*4*l*R*1*D*8*T";

		var expected = new F04_WeightVolumeLoss()
		{
			Weight = 1,
			WeightUnitCode = "L",
			WeightQualifier = "M",
			Weight2 = 4,
			WeightUnitCode2 = "l",
			WeightQualifier2 = "R",
			Volume = 1,
			VolumeUnitQualifier = "D",
			Volume2 = 8,
			VolumeUnitQualifier2 = "T",
		};

		var actual = Map.MapObject<F04_WeightVolumeLoss>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", 0, "", 0, 0, true)]
	[InlineData(1, "L", 1, "M", 1, 4, true)]
	[InlineData(1, "", 0, "", 0, 0, false)]
	[InlineData(0, "L", 1, "M", 1, 4, true)]
	public void Validation_ARequiresBWeight(decimal weight, string weightUnitCode, decimal weight2, string weightQualifier, decimal weight3, decimal weight4, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
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
			subject.WeightUnitCode2 = "l";
			subject.WeightQualifier2 = "R";
}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", 0, "", true)]
	[InlineData(4, "l", 4, "R", true)]
	[InlineData(4, "", 0, "", false)]
	[InlineData(0, "l", 4, "R", true)]
	public void Validation_ARequiresBWeight2(decimal weight2, string weightUnitCode2, decimal weight3, string weightQualifier2, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (weight2 > 0) 
			subject.Weight2 = weight2;
		subject.WeightUnitCode2 = weightUnitCode2;
		if (weight2 > 0) 
			subject.Weight2 = weight2;
		subject.WeightQualifier2 = weightQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", 0, 0, true)]
	[InlineData(1, "D", 1, 8, true)]
	[InlineData(1, "", 0, 0, false)]
	[InlineData(0, "D", 1, 8, true)]
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
		if (volume2 > 0)
			subject.VolumeUnitQualifier2 = "T";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "T", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "T", true)]
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
