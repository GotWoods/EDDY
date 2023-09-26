using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*B*n*Xz*7*P*9*4*GK*5*f*6";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "B",
			CommodityCode = "n",
			QuantityQualifier = "Xz",
			Quantity = 7,
			AmountQualifierCode = "P",
			MonetaryAmount = 9,
			AssignedNumber = 4,
			QuantityQualifier2 = "GK",
			Quantity2 = 5,
			WeightUnitCode = "f",
			Weight = 6,
		};

		var actual = Map.MapObject<L13_CommodityDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCode = "n";
		subject.QuantityQualifier = "Xz";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "P";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 4;
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.QuantityQualifier = "Xz";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "P";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 4;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xz", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = "n";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "P";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 4;
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = "n";
		subject.QuantityQualifier = "Xz";
		subject.AmountQualifierCode = "P";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 4;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = "n";
		subject.QuantityQualifier = "Xz";
		subject.Quantity = 7;
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 4;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = "n";
		subject.QuantityQualifier = "Xz";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "P";
		subject.AssignedNumber = 4;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = "n";
		subject.QuantityQualifier = "Xz";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "P";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("GK", 5, true)]
	[InlineData("GK", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = "n";
		subject.QuantityQualifier = "Xz";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "P";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 4;
		//Test Parameters
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "f";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("f", 6, true)]
	[InlineData("f", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = "n";
		subject.QuantityQualifier = "Xz";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "P";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 4;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "GK";
			subject.Quantity2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
