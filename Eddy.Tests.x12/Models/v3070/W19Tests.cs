using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class W19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W19*4k*9*rk*IoUVhJpyJXUS*gD*O*Ur*c*7*6*v*Y*4*p*6*l*xt*h";

		var expected = new W19_WarehouseAdjustmentItemDetail()
		{
			QuantityOrStatusAdjustmentReasonCode = "4k",
			CreditDebitQuantity = 9,
			UnitOrBasisForMeasurementCode = "rk",
			UPCCaseCode = "IoUVhJpyJXUS",
			ProductServiceIDQualifier = "gD",
			ProductServiceID = "O",
			ProductServiceIDQualifier2 = "Ur",
			ProductServiceID2 = "c",
			WarehouseLotNumber = "7",
			Weight = 6,
			WeightQualifier = "v",
			WeightUnitCode = "Y",
			Weight2 = 4,
			WeightQualifier2 = "p",
			WeightUnitCode2 = "6",
			InventoryTransactionTypeCode = "l",
			ProductServiceIDQualifier3 = "xt",
			ProductServiceID3 = "h",
		};

		var actual = Map.MapObject<W19_WarehouseAdjustmentItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4k", true)]
	public void Validation_RequiredQuantityOrStatusAdjustmentReasonCode(string quantityOrStatusAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.CreditDebitQuantity = 9;
		subject.UnitOrBasisForMeasurementCode = "rk";
		//Test Parameters
		subject.QuantityOrStatusAdjustmentReasonCode = quantityOrStatusAdjustmentReasonCode;
		//At Least one
		subject.UPCCaseCode = "IoUVhJpyJXUS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gD";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ur";
			subject.ProductServiceID2 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "xt";
			subject.ProductServiceID3 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredCreditDebitQuantity(decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "4k";
		subject.UnitOrBasisForMeasurementCode = "rk";
		//Test Parameters
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		//At Least one
		subject.UPCCaseCode = "IoUVhJpyJXUS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gD";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ur";
			subject.ProductServiceID2 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "xt";
			subject.ProductServiceID3 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rk", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "4k";
		subject.CreditDebitQuantity = 9;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "IoUVhJpyJXUS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gD";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ur";
			subject.ProductServiceID2 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "xt";
			subject.ProductServiceID3 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("IoUVhJpyJXUS", "gD", true)]
	[InlineData("IoUVhJpyJXUS", "", true)]
	[InlineData("", "gD", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "4k";
		subject.CreditDebitQuantity = 9;
		subject.UnitOrBasisForMeasurementCode = "rk";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gD";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ur";
			subject.ProductServiceID2 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "xt";
			subject.ProductServiceID3 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gD", "O", true)]
	[InlineData("gD", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "4k";
		subject.CreditDebitQuantity = 9;
		subject.UnitOrBasisForMeasurementCode = "rk";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "IoUVhJpyJXUS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ur";
			subject.ProductServiceID2 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "xt";
			subject.ProductServiceID3 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ur", "c", true)]
	[InlineData("Ur", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "4k";
		subject.CreditDebitQuantity = 9;
		subject.UnitOrBasisForMeasurementCode = "rk";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "IoUVhJpyJXUS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gD";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "xt";
			subject.ProductServiceID3 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xt", "h", true)]
	[InlineData("xt", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "4k";
		subject.CreditDebitQuantity = 9;
		subject.UnitOrBasisForMeasurementCode = "rk";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//At Least one
		subject.UPCCaseCode = "IoUVhJpyJXUS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gD";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ur";
			subject.ProductServiceID2 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
