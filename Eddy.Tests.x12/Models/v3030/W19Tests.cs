using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W19*PK*2*xn*1k8ObmgPcnyb*oq*h*pr*a*5*7*r*q*1*j*y";

		var expected = new W19_WarehouseAdjustmentItemDetail()
		{
			QuantityOrStatusAdjustmentReasonCode = "PK",
			CreditDebitQuantity = 2,
			UnitOrBasisForMeasurementCode = "xn",
			UPCCaseCode = "1k8ObmgPcnyb",
			ProductServiceIDQualifier = "oq",
			ProductServiceID = "h",
			ProductServiceIDQualifier2 = "pr",
			ProductServiceID2 = "a",
			WarehouseLotNumber = "5",
			Weight = 7,
			WeightQualifier = "r",
			WeightUnitCode = "q",
			Weight2 = 1,
			WeightQualifier2 = "j",
			WeightUnitCode2 = "y",
		};

		var actual = Map.MapObject<W19_WarehouseAdjustmentItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PK", true)]
	public void Validation_RequiredQuantityOrStatusAdjustmentReasonCode(string quantityOrStatusAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "xn";
		//Test Parameters
		subject.QuantityOrStatusAdjustmentReasonCode = quantityOrStatusAdjustmentReasonCode;
		//At Least one
		subject.UPCCaseCode = "1k8ObmgPcnyb";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "oq";
			subject.ProductServiceID = "h";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "pr";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredCreditDebitQuantity(decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "PK";
		subject.UnitOrBasisForMeasurementCode = "xn";
		//Test Parameters
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		//At Least one
		subject.UPCCaseCode = "1k8ObmgPcnyb";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "oq";
			subject.ProductServiceID = "h";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "pr";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xn", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "PK";
		subject.CreditDebitQuantity = 2;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "1k8ObmgPcnyb";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "oq";
			subject.ProductServiceID = "h";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "pr";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("1k8ObmgPcnyb", "oq", true)]
	[InlineData("1k8ObmgPcnyb", "", true)]
	[InlineData("", "oq", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "PK";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "xn";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "oq";
			subject.ProductServiceID = "h";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "pr";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oq", "h", true)]
	[InlineData("oq", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "PK";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "xn";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "1k8ObmgPcnyb";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "pr";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pr", "a", true)]
	[InlineData("pr", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "PK";
		subject.CreditDebitQuantity = 2;
		subject.UnitOrBasisForMeasurementCode = "xn";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "1k8ObmgPcnyb";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "oq";
			subject.ProductServiceID = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
