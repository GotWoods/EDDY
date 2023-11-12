using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT8*Q*n*3*2*9*j*7";

		var expected = new AT8_ShipmentWeightPackagingAndQuantityData()
		{
			WeightQualifier = "Q",
			WeightUnitCode = "n",
			Weight = 3,
			LadingQuantity = 2,
			LadingQuantity2 = 9,
			VolumeUnitQualifier = "j",
			Volume = 7,
		};

		var actual = Map.MapObject<AT8_ShipmentWeightPackagingAndQuantityData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("j", 7, true)]
	[InlineData("j", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new AT8_ShipmentWeightPackagingAndQuantityData();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
