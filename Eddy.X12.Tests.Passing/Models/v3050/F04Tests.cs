using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class F04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F04*5*l*x*2*I*u*8*l*8*5";

		var expected = new F04_WeightVolumeLoss()
		{
			Weight = 5,
			WeightUnitCode = "l",
			WeightQualifier = "x",
			Weight2 = 2,
			WeightUnitCode2 = "I",
			WeightQualifier2 = "u",
			Volume = 8,
			VolumeUnitQualifier = "l",
			Volume2 = 8,
			VolumeUnitQualifier2 = "5",
		};

		var actual = Map.MapObject<F04_WeightVolumeLoss>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 2, true)]
	[InlineData(5, 0, false)]
	[InlineData(0, 2, true)]
	public void Validation_ARequiresBWeight(decimal weight, decimal weight2, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		if (weight2 > 0) 
			subject.Weight2 = weight2;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "l";
		}
		if(subject.Volume2 > 0 || subject.Volume2 > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier2))
		{
			subject.Volume2 = 8;
			subject.VolumeUnitQualifier2 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}


	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "5", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "5", false)]
	public void Validation_AllAreRequiredVolume2(decimal volume2, string volumeUnitQualifier2, bool isValidExpected)
	{
		var subject = new F04_WeightVolumeLoss();
		//Required fields
		//Test Parameters
		if (volume2 > 0) 
			subject.Volume2 = volume2;
		subject.VolumeUnitQualifier2 = volumeUnitQualifier2;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
