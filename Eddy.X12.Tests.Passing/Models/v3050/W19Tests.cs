using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W19*n4*6*cC*ettNbgjpe2BR*V0*3*OV*H*Q*8*2*l*6*t*6*Z";

		var expected = new W19_WarehouseAdjustmentItemDetail()
		{
			QuantityOrStatusAdjustmentReasonCode = "n4",
			CreditDebitQuantity = 6,
			UnitOrBasisForMeasurementCode = "cC",
			UPCCaseCode = "ettNbgjpe2BR",
			ProductServiceIDQualifier = "V0",
			ProductServiceID = "3",
			ProductServiceIDQualifier2 = "OV",
			ProductServiceID2 = "H",
			WarehouseLotNumber = "Q",
			Weight = 8,
			WeightQualifier = "2",
			WeightUnitCode = "l",
			Weight2 = 6,
			WeightQualifier2 = "t",
			WeightUnitCode2 = "6",
			InventoryTransactionTypeCode = "Z",
		};

		var actual = Map.MapObject<W19_WarehouseAdjustmentItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n4", true)]
	public void Validation_RequiredQuantityOrStatusAdjustmentReasonCode(string quantityOrStatusAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.CreditDebitQuantity = 6;
		subject.UnitOrBasisForMeasurementCode = "cC";
		//Test Parameters
		subject.QuantityOrStatusAdjustmentReasonCode = quantityOrStatusAdjustmentReasonCode;
		//At Least one
		subject.UPCCaseCode = "ettNbgjpe2BR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "V0";
			subject.ProductServiceID = "3";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "OV";
			subject.ProductServiceID2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredCreditDebitQuantity(decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "n4";
		subject.UnitOrBasisForMeasurementCode = "cC";
		//Test Parameters
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		//At Least one
		subject.UPCCaseCode = "ettNbgjpe2BR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "V0";
			subject.ProductServiceID = "3";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "OV";
			subject.ProductServiceID2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cC", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "n4";
		subject.CreditDebitQuantity = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "ettNbgjpe2BR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "V0";
			subject.ProductServiceID = "3";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "OV";
			subject.ProductServiceID2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ettNbgjpe2BR", "V0", true)]
	[InlineData("ettNbgjpe2BR", "", true)]
	[InlineData("", "V0", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "n4";
		subject.CreditDebitQuantity = 6;
		subject.UnitOrBasisForMeasurementCode = "cC";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "V0";
			subject.ProductServiceID = "3";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "OV";
			subject.ProductServiceID2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V0", "3", true)]
	[InlineData("V0", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "n4";
		subject.CreditDebitQuantity = 6;
		subject.UnitOrBasisForMeasurementCode = "cC";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "ettNbgjpe2BR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "OV";
			subject.ProductServiceID2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OV", "H", true)]
	[InlineData("OV", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "n4";
		subject.CreditDebitQuantity = 6;
		subject.UnitOrBasisForMeasurementCode = "cC";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "ettNbgjpe2BR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "V0";
			subject.ProductServiceID = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
