using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*T*d*a0*8*J*4*9*iR*9*T*9*q*Zx*U*H*e";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "T",
			CommodityCode = "d",
			UnitOrBasisForMeasurementCode = "a0",
			Quantity = 8,
			AmountQualifierCode = "J",
			MonetaryAmount = 4,
			AssignedNumber = 9,
			UnitOrBasisForMeasurementCode2 = "iR",
			Quantity2 = 9,
			WeightUnitCode = "T",
			Weight = 9,
			FreeFormDescription = "q",
			ExportExceptionCode = "Zx",
			ActionCode = "U",
			HarborMaintenanceFeeHMFExemptionCode = "H",
			Amount = "e",
		};

		var actual = Map.MapObject<L13_CommodityDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a0", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.AssignedNumber = 9;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
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
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("iR", 9, true)]
	[InlineData("iR", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("T", 9, true)]
	[InlineData("T", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "H";
			subject.Amount = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "e", true)]
	[InlineData("H", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredHarborMaintenanceFeeHMFExemptionCode(string harborMaintenanceFeeHMFExemptionCode, string amount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "T";
		subject.CommodityCode = "d";
		subject.UnitOrBasisForMeasurementCode = "a0";
		subject.Quantity = 8;
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 4;
		subject.AssignedNumber = 9;
		//Test Parameters
		subject.HarborMaintenanceFeeHMFExemptionCode = harborMaintenanceFeeHMFExemptionCode;
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iR";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "T";
			subject.Weight = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
