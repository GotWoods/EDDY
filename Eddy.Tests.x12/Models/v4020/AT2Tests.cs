using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class AT2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT2*1*EHE*j*2*5*4*5aZ*y*W*sx";

		var expected = new AT2_BillOfLadingLineItemDetail()
		{
			LadingQuantity = 1,
			PackagingFormCode = "EHE",
			WeightQualifier = "j",
			WeightUnitCode = "2",
			Weight = 5,
			LadingQuantity2 = 4,
			PackagingFormCode2 = "5aZ",
			YesNoConditionOrResponseCode = "y",
			CommodityCode = "W",
			FreightClassCode = "sx",
		};

		var actual = Map.MapObject<AT2_BillOfLadingLineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "EHE", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "EHE", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string packagingFormCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "j";
		subject.WeightUnitCode = "2";
		subject.Weight = 5;
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		subject.PackagingFormCode = packagingFormCode;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 4;
			subject.PackagingFormCode2 = "5aZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightUnitCode = "2";
		subject.Weight = 5;
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "EHE";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 4;
			subject.PackagingFormCode2 = "5aZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "j";
		subject.Weight = 5;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "EHE";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 4;
			subject.PackagingFormCode2 = "5aZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "j";
		subject.WeightUnitCode = "2";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "EHE";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 4;
			subject.PackagingFormCode2 = "5aZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "5aZ", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "5aZ", false)]
	public void Validation_AllAreRequiredLadingQuantity2(int ladingQuantity2, string packagingFormCode2, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "j";
		subject.WeightUnitCode = "2";
		subject.Weight = 5;
		//Test Parameters
		if (ladingQuantity2 > 0) 
			subject.LadingQuantity2 = ladingQuantity2;
		subject.PackagingFormCode2 = packagingFormCode2;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 1;
			subject.PackagingFormCode = "EHE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
