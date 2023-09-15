using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class L0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L0*7*3*Vy*7*u*8*v*4*o0z*lV*H*R7*7*QHj*Y";

		var expected = new L0_LineItemQuantityAndWeight()
		{
			LadingLineItemNumber = 7,
			BilledRatedAsQuantity = 3,
			BilledRatedAsQualifier = "Vy",
			Weight = 7,
			WeightQualifier = "u",
			Volume = 8,
			VolumeUnitQualifier = "v",
			LadingQuantity = 4,
			PackagingFormCode = "o0z",
			DunnageDescription = "lV",
			WeightUnitCode = "H",
			TypeOfServiceCode = "R7",
			Quantity = 7,
			PackagingFormCode2 = "QHj",
			YesNoConditionOrResponseCode = "Y",
		};

		var actual = Map.MapObject<L0_LineItemQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Vy", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Vy", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 7;
			subject.WeightQualifier = "u";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "v";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 4;
			subject.PackagingFormCode = "o0z";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 7;
			subject.YesNoConditionOrResponseCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "u", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "u", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "Vy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "v";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 4;
			subject.PackagingFormCode = "o0z";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 7;
			subject.YesNoConditionOrResponseCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "v", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "v", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "Vy";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 7;
			subject.WeightQualifier = "u";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 4;
			subject.PackagingFormCode = "o0z";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 7;
			subject.YesNoConditionOrResponseCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "o0z", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "o0z", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string packagingFormCode, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		subject.PackagingFormCode = packagingFormCode;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "Vy";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 7;
			subject.WeightQualifier = "u";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "v";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 7;
			subject.YesNoConditionOrResponseCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("H", 7, true)]
	[InlineData("H", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "Vy";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 7;
			subject.WeightQualifier = "u";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "v";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 4;
			subject.PackagingFormCode = "o0z";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 7;
			subject.YesNoConditionOrResponseCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Y", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Y", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 3;
			subject.BilledRatedAsQualifier = "Vy";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 7;
			subject.WeightQualifier = "u";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "v";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 4;
			subject.PackagingFormCode = "o0z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
