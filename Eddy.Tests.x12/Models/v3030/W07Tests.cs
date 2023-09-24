using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W07*1*bd*mOwPuFtAhivN*FF*s*Rk*s*6*Q";

		var expected = new W07_ItemDetailForStockReceipt()
		{
			QuantityReceived = 1,
			UnitOrBasisForMeasurementCode = "bd",
			UPCCaseCode = "mOwPuFtAhivN",
			ProductServiceIDQualifier = "FF",
			ProductServiceID = "s",
			ProductServiceIDQualifier2 = "Rk",
			ProductServiceID2 = "s",
			WarehouseLotNumber = "6",
			WarehouseDetailAdjustmentIdentifier = "Q",
		};

		var actual = Map.MapObject<W07_ItemDetailForStockReceipt>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "bd";
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		//At Least one
		subject.UPCCaseCode = "mOwPuFtAhivN";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "FF";
			subject.ProductServiceID = "s";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Rk";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bd", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 1;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "mOwPuFtAhivN";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "FF";
			subject.ProductServiceID = "s";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Rk";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("mOwPuFtAhivN", "FF", true)]
	[InlineData("mOwPuFtAhivN", "", true)]
	[InlineData("", "FF", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 1;
		subject.UnitOrBasisForMeasurementCode = "bd";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "FF";
			subject.ProductServiceID = "s";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Rk";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FF", "s", true)]
	[InlineData("FF", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 1;
		subject.UnitOrBasisForMeasurementCode = "bd";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "mOwPuFtAhivN";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Rk";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Rk", "s", true)]
	[InlineData("Rk", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 1;
		subject.UnitOrBasisForMeasurementCode = "bd";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "mOwPuFtAhivN";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "FF";
			subject.ProductServiceID = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
