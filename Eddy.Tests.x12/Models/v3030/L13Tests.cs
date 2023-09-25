using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*L*6*yl*5*o*1*9*37*7*G*2";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "L",
			CommodityCode = "6",
			QuantityQualifier = "yl",
			Quantity = 5,
			AmountQualifierCode = "o",
			MonetaryAmount = 1,
			AssignedNumber = 9,
			QuantityQualifier2 = "37",
			Quantity2 = 7,
			WeightUnitCode = "G",
			Weight = 2,
		};

		var actual = Map.MapObject<L13_CommodityDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCode = "6";
		subject.QuantityQualifier = "yl";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "o";
		subject.MonetaryAmount = 1;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.QuantityQualifier = "yl";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "o";
		subject.MonetaryAmount = 1;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yl", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "6";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "o";
		subject.MonetaryAmount = 1;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "6";
		subject.QuantityQualifier = "yl";
		subject.AmountQualifierCode = "o";
		subject.MonetaryAmount = 1;
		subject.AssignedNumber = 9;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "6";
		subject.QuantityQualifier = "yl";
		subject.Quantity = 5;
		subject.MonetaryAmount = 1;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "6";
		subject.QuantityQualifier = "yl";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "o";
		subject.AssignedNumber = 9;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "6";
		subject.QuantityQualifier = "yl";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "o";
		subject.MonetaryAmount = 1;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("37", 7, true)]
	[InlineData("37", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "6";
		subject.QuantityQualifier = "yl";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "o";
		subject.MonetaryAmount = 1;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("G", 2, true)]
	[InlineData("G", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "6";
		subject.QuantityQualifier = "yl";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "o";
		subject.MonetaryAmount = 1;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "37";
			subject.Quantity2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
