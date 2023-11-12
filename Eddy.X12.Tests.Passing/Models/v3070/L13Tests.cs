using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*2*2*z3*4*I*9*3*3q*1*X*2*m*E*p*i*5";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "2",
			CommodityCode = "2",
			QuantityQualifier = "z3",
			Quantity = 4,
			AmountQualifierCode = "I",
			MonetaryAmount = 9,
			AssignedNumber = 3,
			QuantityQualifier2 = "3q",
			Quantity2 = 1,
			WeightUnitCode = "X",
			Weight = 2,
			FreeFormDescription = "m",
			ExportLicenseSymbolCode = "E",
			ProductServiceID = "p",
			HarborMaintenanceFeeHMFExemptionCode = "i",
			Amount = "5",
		};

		var actual = Map.MapObject<L13_CommodityDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z3", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
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
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.AssignedNumber = 3;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("3q", 1, true)]
	[InlineData("3q", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 2, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "i";
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "5", true)]
	[InlineData("i", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredHarborMaintenanceFeeHMFExemptionCode(string harborMaintenanceFeeHMFExemptionCode, string amount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "2";
		subject.CommodityCode = "2";
		subject.QuantityQualifier = "z3";
		subject.Quantity = 4;
		subject.AmountQualifierCode = "I";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 3;
		//Test Parameters
		subject.HarborMaintenanceFeeHMFExemptionCode = harborMaintenanceFeeHMFExemptionCode;
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "3q";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "X";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
