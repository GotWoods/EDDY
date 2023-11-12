using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*D*1*J1*3*2*3*1*O3*8*E*7*j*89*5*T*O";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "D",
			CommodityCode = "1",
			UnitOrBasisForMeasurementCode = "J1",
			Quantity = 3,
			AmountQualifierCode = "2",
			MonetaryAmount = 3,
			AssignedNumber = 1,
			UnitOrBasisForMeasurementCode2 = "O3",
			Quantity2 = 8,
			WeightUnitCode = "E",
			Weight = 7,
			FreeFormDescription = "j",
			ExportExceptionCode = "89",
			ActionCode = "5",
			HarborMaintenanceFeeHMFExemptionCode = "T",
			Amount = "O",
		};

		var actual = Map.MapObject<L13_CommodityDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J1", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
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
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.AssignedNumber = 1;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O3", 8, true)]
	[InlineData("O3", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("E", 7, true)]
	[InlineData("E", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.HarborMaintenanceFeeHMFExemptionCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.HarborMaintenanceFeeHMFExemptionCode = "T";
			subject.Amount = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "O", true)]
	[InlineData("T", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredHarborMaintenanceFeeHMFExemptionCode(string harborMaintenanceFeeHMFExemptionCode, string amount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		//Required fields
		subject.CommodityCodeQualifier = "D";
		subject.CommodityCode = "1";
		subject.UnitOrBasisForMeasurementCode = "J1";
		subject.Quantity = 3;
		subject.AmountQualifierCode = "2";
		subject.MonetaryAmount = 3;
		subject.AssignedNumber = 1;
		//Test Parameters
		subject.HarborMaintenanceFeeHMFExemptionCode = harborMaintenanceFeeHMFExemptionCode;
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "O3";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "E";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
