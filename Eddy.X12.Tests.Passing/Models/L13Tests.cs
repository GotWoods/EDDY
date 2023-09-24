using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L13*L*3*ko*7*b*5*3*va*1*Z*9*0*Pi*c*8*2";

		var expected = new L13_CommodityDetails()
		{
			CommodityCodeQualifier = "L",
			CommodityCode = "3",
			UnitOrBasisForMeasurementCode = "ko",
			Quantity = 7,
			AmountQualifierCode = "b",
			MonetaryAmount = 5,
			AssignedNumber = 3,
			UnitOrBasisForMeasurementCode2 = "va",
			Quantity2 = 1,
			WeightUnitCode = "Z",
			Weight = 9,
			FreeFormDescription = "0",
			ExportExceptionCode = "Pi",
			ActionCode = "c",
			HarborMaintenanceFeeHMFExemptionCode = "8",
			Amount = "2",
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
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ko", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.AssignedNumber = 3;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("va", 1, true)]
	[InlineData("", 1, false)]
	[InlineData("va", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Z", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("Z", 0, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("8", "", false)]
	public void Validation_AllAreRequiredHarborMaintenanceFeeHMFExemptionCode(string harborMaintenanceFeeHMFExemptionCode, string amount, bool isValidExpected)
	{
		var subject = new L13_CommodityDetails();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "3";
		subject.UnitOrBasisForMeasurementCode = "ko";
		subject.Quantity = 7;
		subject.AmountQualifierCode = "b";
		subject.MonetaryAmount = 5;
		subject.AssignedNumber = 3;
		subject.HarborMaintenanceFeeHMFExemptionCode = harborMaintenanceFeeHMFExemptionCode;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
