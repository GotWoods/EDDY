using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W07*6*De*yDqH6FKKrtON*iI*j*9R*j*s*d*yi*D";

		var expected = new W07_ItemDetailForStockReceipt()
		{
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "De",
			UPCCaseCode = "yDqH6FKKrtON",
			ProductServiceIDQualifier = "iI",
			ProductServiceID = "j",
			ProductServiceIDQualifier2 = "9R",
			ProductServiceID2 = "j",
			WarehouseLotNumber = "s",
			WarehouseDetailAdjustmentIdentifierCode = "d",
			ProductServiceIDQualifier3 = "yi",
			ProductServiceID3 = "D",
		};

		var actual = Map.MapObject<W07_ItemDetailForStockReceipt>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		subject.UnitOrBasisForMeasurementCode = "De";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("De", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("yDqH6FKKrtON","iI", true)]
	[InlineData("", "iI", true)]
	[InlineData("yDqH6FKKrtON", "", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "De";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("iI", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("iI", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "De";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("9R", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("9R", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "De";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("yi", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("yi", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "De";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
