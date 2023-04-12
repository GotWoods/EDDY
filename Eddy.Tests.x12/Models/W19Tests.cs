using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W19*ef*2*TO*1rlH7Mpp5q8q*fy*u*Xl*3*i*6*2*W*6*n*G*s*Y4*J";

		var expected = new W19_WarehouseAdjustmentItemDetail()
		{
			QuantityOrStatusAdjustmentReasonCode = "ef",
			CreditDebitQuantity = 2,
			UnitOrBasisForMeasurementCode = "TO",
			UPCCaseCode = "1rlH7Mpp5q8q",
			ProductServiceIDQualifier = "fy",
			ProductServiceID = "u",
			ProductServiceIDQualifier2 = "Xl",
			ProductServiceID2 = "3",
			WarehouseLotNumber = "i",
			Weight = 6,
			WeightQualifier = "2",
			WeightUnitCode = "W",
			Weight2 = 6,
			WeightQualifier2 = "n",
			WeightUnitCode2 = "G",
			InventoryTransactionTypeCode = "s",
			ProductServiceIDQualifier3 = "Y4",
			ProductServiceID3 = "J",
		};

		var actual = Map.MapObject<W19_WarehouseAdjustmentItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ef", true)]
	public void Validation_RequiredQuantityOrStatusAdjustmentReasonCode(string quantityOrStatusAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "TO";
		subject.QuantityOrStatusAdjustmentReasonCode = quantityOrStatusAdjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredCreditDebitQuantity(decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		subject.QuantityOrStatusAdjustmentReasonCode = "ef";
		subject.UnitOrBasisForMeasurementCode = "TO";
		if (creditDebitQuantity > 0)
		subject.CreditDebitQuantity = creditDebitQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TO", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		subject.QuantityOrStatusAdjustmentReasonCode = "ef";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("1rlH7Mpp5q8q","fy", true)]
	[InlineData("", "fy", true)]
	[InlineData("1rlH7Mpp5q8q", "", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		subject.QuantityOrStatusAdjustmentReasonCode = "ef";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "TO";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("fy", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("fy", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		subject.QuantityOrStatusAdjustmentReasonCode = "ef";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "TO";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Xl", "3", true)]
	[InlineData("", "3", false)]
	[InlineData("Xl", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		subject.QuantityOrStatusAdjustmentReasonCode = "ef";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "TO";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Y4", "J", true)]
	[InlineData("", "J", false)]
	[InlineData("Y4", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		subject.QuantityOrStatusAdjustmentReasonCode = "ef";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "TO";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
