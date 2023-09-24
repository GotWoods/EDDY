using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class L0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L0*4*1*mg*4*Y*2*E*6*lsM*vE*n*JT";

		var expected = new L0_LineItemQuantityAndWeight()
		{
			LadingLineItemNumber = 4,
			BilledRatedAsQuantity = 1,
			BilledRatedAsQualifier = "mg",
			Weight = 4,
			WeightQualifier = "Y",
			Volume = 2,
			VolumeUnitQualifier = "E",
			LadingQuantity = 6,
			PackagingFormCode = "lsM",
			DunnageDescription = "vE",
			WeightUnitCode = "n",
			TypeOfServiceCode = "JT",
		};

		var actual = Map.MapObject<L0_LineItemQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "mg", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "mg", false)]
	public void Validation_AllAreRequiredBilledRatedAsQuantity(decimal billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		if (billedRatedAsQuantity > 0)
			subject.BilledRatedAsQuantity = billedRatedAsQuantity;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 4;
			subject.WeightQualifier = "Y";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "E";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "lsM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Y", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Y", false)]
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
			subject.BilledRatedAsQualifier = "mg";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "E";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "lsM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "E", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "E", false)]
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
			subject.BilledRatedAsQualifier = "mg";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 4;
			subject.WeightQualifier = "Y";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "lsM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "lsM", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "lsM", false)]
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
			subject.BilledRatedAsQualifier = "mg";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 4;
			subject.WeightQualifier = "Y";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 4, true)]
	[InlineData("n", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L0_LineItemQuantityAndWeight();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.BilledRatedAsQuantity > 0 || subject.BilledRatedAsQuantity > 0 || !string.IsNullOrEmpty(subject.BilledRatedAsQualifier))
		{
			subject.BilledRatedAsQuantity = 1;
			subject.BilledRatedAsQualifier = "mg";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 4;
			subject.WeightQualifier = "Y";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "E";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "lsM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
