using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT2*2*zBI*Z*1*3*6*3cf*y*6*Af";

		var expected = new AT2_BillOfLadingLineItemDetail()
		{
			LadingQuantity = 2,
			PackagingFormCode = "zBI",
			WeightQualifier = "Z",
			WeightUnitCode = "1",
			Weight = 3,
			LadingQuantity2 = 6,
			PackagingFormCode2 = "3cf",
			YesNoConditionOrResponseCode = "y",
			CommodityCode = "6",
			FreightClassCode = "Af",
		};

		var actual = Map.MapObject<AT2_BillOfLadingLineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredLadingQuantity(int ladingQuantity, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.PackagingFormCode = "zBI";
		subject.WeightQualifier = "Z";
		subject.WeightUnitCode = "1";
		subject.Weight = 3;
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "3cf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zBI", true)]
	public void Validation_RequiredPackagingFormCode(string packagingFormCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.LadingQuantity = 2;
		subject.WeightQualifier = "Z";
		subject.WeightUnitCode = "1";
		subject.Weight = 3;
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "3cf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.LadingQuantity = 2;
		subject.PackagingFormCode = "zBI";
		subject.WeightUnitCode = "1";
		subject.Weight = 3;
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "3cf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.LadingQuantity = 2;
		subject.PackagingFormCode = "zBI";
		subject.WeightQualifier = "Z";
		subject.Weight = 3;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "3cf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.LadingQuantity = 2;
		subject.PackagingFormCode = "zBI";
		subject.WeightQualifier = "Z";
		subject.WeightUnitCode = "1";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "3cf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "3cf", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "3cf", false)]
	public void Validation_AllAreRequiredLadingQuantity2(int ladingQuantity2, string packagingFormCode2, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.LadingQuantity = 2;
		subject.PackagingFormCode = "zBI";
		subject.WeightQualifier = "Z";
		subject.WeightUnitCode = "1";
		subject.Weight = 3;
		//Test Parameters
		if (ladingQuantity2 > 0) 
			subject.LadingQuantity2 = ladingQuantity2;
		subject.PackagingFormCode2 = packagingFormCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
