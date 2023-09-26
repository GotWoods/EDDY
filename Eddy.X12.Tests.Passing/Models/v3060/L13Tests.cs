using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*u*9*Iw*3*U*9*6*rd*3*n*7*m*M*k*u*A";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "u",
			CommodityCode = "9",
			QuantityQualifier = "Iw",
			Quantity = 3,
			AmountQualifierCode = "U",
			MonetaryAmount = 9,
			AssignedNumber = 6,
			QuantityQualifier2 = "rd",
			Quantity2 = 3,
			WeightUnitCode = "n",
			Weight = 7,
			FreeFormDescription = "m",
			ExportLicenseSymbolCode = "M",
			ProductServiceID = "k",
			HarborMaintenanceFeeHMFExemptionCode = "u",
			Amount = "A",
		};

		var actual = Map.MapObject<L13_CommodityDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iw", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
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
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.AssignedNumber = 6;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rd", 3, true)]
	[InlineData("rd", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 7, true)]
	[InlineData("n", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "u";
			subject.Amount = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "A", true)]
	[InlineData("u", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredHarborMaintenanceFeeHMFExemptionCode(string harborMaintenanceFeeHMFExemptionCode, string amount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "u";
		subject.CommodityCode = "9";
		subject.QuantityQualifier = "Iw";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "U";
		subject.MonetaryAmount = 9;
		subject.AssignedNumber = 6;
		//Test Parameters
		subject.HarborMaintenanceFeeHMFExemptionCode = harborMaintenanceFeeHMFExemptionCode;
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "rd";
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "n";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
