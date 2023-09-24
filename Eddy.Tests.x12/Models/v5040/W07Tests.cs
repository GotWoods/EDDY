using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class W07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W07*8*Wc*kcQmXTFjI8in*2s*R*8Z*b*o*z*kJ*f";

		var expected = new W07_ItemDetailForStockReceipt()
		{
			Quantity = 8,
			UnitOrBasisForMeasurementCode = "Wc",
			UPCCaseCode = "kcQmXTFjI8in",
			ProductServiceIDQualifier = "2s",
			ProductServiceID = "R",
			ProductServiceIDQualifier2 = "8Z",
			ProductServiceID2 = "b",
			WarehouseLotNumber = "o",
			WarehouseDetailAdjustmentIdentifier = "z",
			ProductServiceIDQualifier3 = "kJ",
			ProductServiceID3 = "f",
		};

		var actual = Map.MapObject<W07_ItemDetailForStockReceipt>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Wc";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.UPCCaseCode = "kcQmXTFjI8in";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2s";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "8Z";
			subject.ProductServiceID2 = "b";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kJ";
			subject.ProductServiceID3 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wc", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.Quantity = 8;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "kcQmXTFjI8in";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2s";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "8Z";
			subject.ProductServiceID2 = "b";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kJ";
			subject.ProductServiceID3 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("kcQmXTFjI8in", "2s", true)]
	[InlineData("kcQmXTFjI8in", "", true)]
	[InlineData("", "2s", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "Wc";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2s";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "8Z";
			subject.ProductServiceID2 = "b";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kJ";
			subject.ProductServiceID3 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2s", "R", true)]
	[InlineData("2s", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "Wc";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "kcQmXTFjI8in";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "8Z";
			subject.ProductServiceID2 = "b";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kJ";
			subject.ProductServiceID3 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8Z", "b", true)]
	[InlineData("8Z", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "Wc";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "kcQmXTFjI8in";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2s";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kJ";
			subject.ProductServiceID3 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kJ", "f", true)]
	[InlineData("kJ", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "Wc";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//At Least one
		subject.UPCCaseCode = "kcQmXTFjI8in";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2s";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "8Z";
			subject.ProductServiceID2 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
