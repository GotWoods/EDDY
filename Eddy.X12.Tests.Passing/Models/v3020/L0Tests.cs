using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L0*2*1*v7*5*Z*8*l*5*4IL*oJ*R*fi";

		var expected = new L0_LineItemQuantityAndWeight()
		{
			LadingLineItemNumber = 2,
			BilledRatedAsQuantity = 1,
			BilledRatedAsQualifier = "v7",
			Weight = 5,
			WeightQualifier = "Z",
			Volume = 8,
			VolumeUnitQualifier = "l",
			LadingQuantity = 5,
			PackagingFormCode = "4IL",
			DunnageDescription = "oJ",
			WeightUnitQualifier = "R",
			TypeOfServiceCode = "fi",
		};

		var actual = Map.MapObject<L0_LineItemQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "v7", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "v7", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 5;
			subject.WeightQualifier = "Z";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "l";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 5;
			subject.PackagingFormCode = "4IL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Z", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Z", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "v7";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "l";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 5;
			subject.PackagingFormCode = "4IL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "l", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "l", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "v7";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 5;
			subject.WeightQualifier = "Z";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 5;
			subject.PackagingFormCode = "4IL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "4IL", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "4IL", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string packagingFormCode, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		subject.PackagingFormCode = packagingFormCode;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "v7";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 5;
			subject.WeightQualifier = "Z";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("R", 5, true)]
	[InlineData("R", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBWeightUnitQualifier(string weightUnitQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		subject.WeightUnitQualifier = weightUnitQualifier;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "v7";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 5;
			subject.WeightQualifier = "Z";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "l";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 5;
			subject.PackagingFormCode = "4IL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
