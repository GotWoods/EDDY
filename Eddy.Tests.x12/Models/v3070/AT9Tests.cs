using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT9*9859*3*1*x*o*2*C*6";

		var expected = new AT9_TrailerOrContainerDimensionAndWeight()
		{
			EquipmentLength = 9859,
			Height = 3,
			Width = 1,
			WeightQualifier = "x",
			WeightUnitCode = "o",
			Weight = 2,
			VolumeUnitQualifier = "C",
			Volume = 6,
		};

		var actual = Map.MapObject<AT9_TrailerOrContainerDimensionAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("C", 6, true)]
	[InlineData("C", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new AT9_TrailerOrContainerDimensionAndWeight();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
