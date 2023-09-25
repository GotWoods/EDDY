using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W07*6*AV*kQjTm7ZE8VY3*HA*k*fj*w*5*Q";

		var expected = new W07_ItemDetailForStockReceipt()
		{
			QuantityReceived = 6,
			UnitOfMeasurementCode = "AV",
			UPCCaseCode = "kQjTm7ZE8VY3",
			ProductServiceIDQualifier = "HA",
			ProductServiceID = "k",
			ProductServiceIDQualifier2 = "fj",
			ProductServiceID2 = "w",
			WarehouseLotNumber = "5",
			WarehouseDetailAdjustmentIdentifier = "Q",
		};

		var actual = Map.MapObject<W07_ItemDetailForStockReceipt>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.UnitOfMeasurementCode = "AV";
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AV", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 6;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
