using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS1*z*J*2*1*2";

		var expected = new TS1_TariffSection()
		{
			FreeFormDescription = "z",
			WeightUnitQualifier = "J",
			Quantity = 2,
			VolumeUnitQualifier = "1",
			Quantity2 = 2,
		};

		var actual = Map.MapObject<TS1_TariffSection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new TS1_TariffSection();
		subject.FreeFormDescription = freeFormDescription;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.Quantity > 0)
		{
			subject.WeightUnitQualifier = "J";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Quantity2 > 0)
		{
			subject.VolumeUnitQualifier = "1";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("J", 2, true)]
	[InlineData("J", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier(string weightUnitQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new TS1_TariffSection();
		subject.FreeFormDescription = "z";
		subject.WeightUnitQualifier = weightUnitQualifier;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Quantity2 > 0)
		{
			subject.VolumeUnitQualifier = "1";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1", 2, true)]
	[InlineData("1", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal quantity2, bool isValidExpected)
	{
		var subject = new TS1_TariffSection();
		subject.FreeFormDescription = "z";
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.Quantity > 0)
		{
			subject.WeightUnitQualifier = "J";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
