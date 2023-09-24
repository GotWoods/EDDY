using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ID4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID4*uH*8*Q*6*X*3*4*o*C";

		var expected = new ID4_LoadDetails()
		{
			DeclaredValue = "uH",
			PickupOrDeliveryCode = "8",
			WeightQualifier = "Q",
			Weight = 6,
			VolumeUnitQualifier = "X",
			Volume = 3,
			Number = 4,
			YesNoConditionOrResponseCode = "o",
			YesNoConditionOrResponseCode2 = "C",
		};

		var actual = Map.MapObject<ID4_LoadDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Q", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("Q", 0, false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new ID4_LoadDetails();
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("X", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("X", 0, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new ID4_LoadDetails();
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0)
		subject.Volume = volume;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
