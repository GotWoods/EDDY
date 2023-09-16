using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS1*u*k*4*B*6";

		var expected = new TS1_TariffSection()
		{
			FreeFormDescription = "u",
			WeightUnitCode = "k",
			Quantity = 4,
			VolumeUnitQualifier = "B",
			Quantity2 = 6,
		};

		var actual = Map.MapObject<TS1_TariffSection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new TS1_TariffSection();
		subject.FreeFormDescription = freeFormDescription;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Quantity > 0)
		{
			subject.WeightUnitCode = "k";
			subject.Quantity = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Quantity2 > 0)
		{
			subject.VolumeUnitQualifier = "B";
			subject.Quantity2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("k", 4, true)]
	[InlineData("k", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal quantity, bool isValidExpected)
	{
		var subject = new TS1_TariffSection();
		subject.FreeFormDescription = "u";
		subject.WeightUnitCode = weightUnitCode;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Quantity2 > 0)
		{
			subject.VolumeUnitQualifier = "B";
			subject.Quantity2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B", 6, true)]
	[InlineData("B", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal quantity2, bool isValidExpected)
	{
		var subject = new TS1_TariffSection();
		subject.FreeFormDescription = "u";
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Quantity > 0)
		{
			subject.WeightUnitCode = "k";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
