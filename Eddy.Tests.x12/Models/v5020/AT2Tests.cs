using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class AT2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT2*6*sr3*o*l*8*2*t8f*d*I*HM*1*46*y*7";

		var expected = new AT2_BillOfLadingLineItemDetail()
		{
			LadingQuantity = 6,
			PackagingFormCode = "sr3",
			WeightQualifier = "o",
			WeightUnitCode = "l",
			Weight = 8,
			LadingQuantity2 = 2,
			PackagingFormCode2 = "t8f",
			YesNoConditionOrResponseCode = "d",
			CommodityCode = "I",
			FreightClassCode = "HM",
			YesNoConditionOrResponseCode2 = "1",
			LadingValue = 46,
			VolumeUnitQualifier = "y",
			Volume = 7,
		};

		var actual = Map.MapObject<AT2_BillOfLadingLineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "sr3", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "sr3", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string packagingFormCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "o";
		subject.WeightUnitCode = "l";
		subject.Weight = 8;
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		subject.PackagingFormCode = packagingFormCode;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 2;
			subject.PackagingFormCode2 = "t8f";
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "y";
			subject.Volume = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightUnitCode = "l";
		subject.Weight = 8;
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "sr3";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 2;
			subject.PackagingFormCode2 = "t8f";
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "y";
			subject.Volume = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "o";
		subject.Weight = 8;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "sr3";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 2;
			subject.PackagingFormCode2 = "t8f";
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "y";
			subject.Volume = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "o";
		subject.WeightUnitCode = "l";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "sr3";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 2;
			subject.PackagingFormCode2 = "t8f";
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "y";
			subject.Volume = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "t8f", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "t8f", false)]
	public void Validation_AllAreRequiredLadingQuantity2(int ladingQuantity2, string packagingFormCode2, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "o";
		subject.WeightUnitCode = "l";
		subject.Weight = 8;
		//Test Parameters
		if (ladingQuantity2 > 0) 
			subject.LadingQuantity2 = ladingQuantity2;
		subject.PackagingFormCode2 = packagingFormCode2;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "sr3";
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "y";
			subject.Volume = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("y", 7, true)]
	[InlineData("y", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "o";
		subject.WeightUnitCode = "l";
		subject.Weight = 8;
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 6;
			subject.PackagingFormCode = "sr3";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 2;
			subject.PackagingFormCode2 = "t8f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
