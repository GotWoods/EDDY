using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class AT2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT2*3*ENg*K*v*6*6*DnO*j*l*Vz*x*37";

		var expected = new AT2_BillOfLadingLineItemDetail()
		{
			LadingQuantity = 3,
			PackagingFormCode = "ENg",
			WeightQualifier = "K",
			WeightUnitCode = "v",
			Weight = 6,
			LadingQuantity2 = 6,
			PackagingFormCode2 = "DnO",
			YesNoConditionOrResponseCode = "j",
			CommodityCode = "l",
			FreightClassCode = "Vz",
			YesNoConditionOrResponseCode2 = "x",
			LadingValue = 37,
		};

		var actual = Map.MapObject<AT2_BillOfLadingLineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "ENg", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "ENg", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string packagingFormCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "K";
		subject.WeightUnitCode = "v";
		subject.Weight = 6;
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		subject.PackagingFormCode = packagingFormCode;
		//If one filled, all required
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "DnO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightUnitCode = "v";
		subject.Weight = 6;
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 3;
			subject.PackagingFormCode = "ENg";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "DnO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "K";
		subject.Weight = 6;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 3;
			subject.PackagingFormCode = "ENg";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "DnO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "K";
		subject.WeightUnitCode = "v";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 3;
			subject.PackagingFormCode = "ENg";
		}
		if(subject.LadingQuantity2 > 0 || subject.LadingQuantity2 > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode2))
		{
			subject.LadingQuantity2 = 6;
			subject.PackagingFormCode2 = "DnO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "DnO", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "DnO", false)]
	public void Validation_AllAreRequiredLadingQuantity2(int ladingQuantity2, string packagingFormCode2, bool isValidExpected)
	{
		var subject = new AT2_BillOfLadingLineItemDetail();
		//Required fields
		subject.WeightQualifier = "K";
		subject.WeightUnitCode = "v";
		subject.Weight = 6;
		//Test Parameters
		if (ladingQuantity2 > 0) 
			subject.LadingQuantity2 = ladingQuantity2;
		subject.PackagingFormCode2 = packagingFormCode2;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.PackagingFormCode))
		{
			subject.LadingQuantity = 3;
			subject.PackagingFormCode = "ENg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
