using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class L0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L0*5*6*3l*9*D*2*r*1*T7r*Kb*0*dF*4*RDO*s";

		var expected = new L0_LineItemQuantityAndWeight()
		{
			LadingLineItemNumber = 5,
			BilledRatedAsQuantity = 6,
			BilledRatedAsQualifier = "3l",
			Weight = 9,
			WeightQualifier = "D",
			Volume = 2,
			VolumeUnitQualifier = "r",
			LadingQuantity = 1,
			PackagingFormCode = "T7r",
			DunnageDescription = "Kb",
			WeightUnitCode = "0",
			TypeOfServiceCode = "dF",
			Quantity = 4,
			PackagingFormCode2 = "RDO",
			YesNoConditionOrResponseCode = "s",
		};

		var actual = Map.MapObject<L0_LineItemQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "3l", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "3l", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "D";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "r";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "T7r";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 4;
			subject.YesNoConditionOrResponseCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "D", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "D", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 6;
			subject.BilledRatedAsQualifier = "3l";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "r";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "T7r";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 4;
			subject.YesNoConditionOrResponseCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "r", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "r", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 6;
			subject.BilledRatedAsQualifier = "3l";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "D";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "T7r";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 4;
			subject.YesNoConditionOrResponseCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "T7r", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "T7r", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string packagingFormCode, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		subject.PackagingFormCode = packagingFormCode;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 6;
			subject.BilledRatedAsQualifier = "3l";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "D";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "r";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 4;
			subject.YesNoConditionOrResponseCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("0", 9, true)]
	[InlineData("0", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 6;
			subject.BilledRatedAsQualifier = "3l";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "D";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "r";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "T7r";
		}
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode))
		{
			subject.Quantity = 4;
			subject.YesNoConditionOrResponseCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "s", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "s", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 6;
			subject.BilledRatedAsQualifier = "3l";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "D";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "r";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "T7r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
