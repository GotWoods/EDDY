using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*b*X*kV*5*6*8*7*V5*4*G*4*C*8m*q*P*z";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "b",
			CommodityCode = "X",
			UnitOrBasisForMeasurementCode = "kV",
			Quantity = 5,
			AmountQualifierCode = "6",
			MonetaryAmount = 8,
			AssignedNumber = 7,
			UnitOrBasisForMeasurementCode2 = "V5",
			Quantity2 = 4,
			WeightUnitCode = "G",
			Weight = 4,
			FreeFormDescription = "C",
			ExportExceptionCode = "8m",
			ActionCode = "q",
			HarborMaintenanceFeeHMFExemptionCode = "P",
			Amount = "z",
		};

		var actual = Map.MapObject<L13_CommodityDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kV", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
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
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.AssignedNumber = 7;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("V5", 4, true)]
	[InlineData("V5", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("G", 4, true)]
	[InlineData("G", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "P";
			subject.Amount = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "z", true)]
	[InlineData("P", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredHarborMaintenanceFeeHMFExemptionCode(string harborMaintenanceFeeHMFExemptionCode, string amount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "X";
		subject.UnitOrBasisForMeasurementCode = "kV";
		subject.Quantity = 5;
		subject.AmountQualifierCode = "6";
		subject.MonetaryAmount = 8;
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.HarborMaintenanceFeeHMFExemptionCode = harborMaintenanceFeeHMFExemptionCode;
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "V5";
			subject.Quantity2 = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "G";
			subject.Weight = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
