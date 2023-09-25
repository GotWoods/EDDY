using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W12*o3*5*4*5*YD*eQSeckEih7xQ*nN*9*J*7*4*p*2*W*c*MffkWSwnzZr4*vP*3*6k*M";

		var expected = new W12_WarehouseItemDetail()
		{
			ShipmentOrderStatusCode = "o3",
			QuantityOrdered = 5,
			NumberOfUnitsShipped = 4,
			QuantityDifference = 5,
			UnitOfMeasurementCode = "YD",
			UPCCaseCode = "eQSeckEih7xQ",
			ProductServiceIDQualifier = "nN",
			ProductServiceID = "9",
			WarehouseLotNumber = "J",
			Weight = 7,
			WeightQualifier = "4",
			WeightUnitQualifier = "p",
			Weight2 = 2,
			WeightQualifier2 = "W",
			WeightUnitQualifier2 = "c",
			UPCCaseCode2 = "MffkWSwnzZr4",
			ProductServiceIDQualifier2 = "vP",
			ProductServiceID2 = "3",
			LineItemChangeReasonCode = "6k",
			WarehouseDetailAdjustmentIdentifier = "M",
		};

		var actual = Map.MapObject<W12_WarehouseItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o3", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.QuantityOrdered = 5;
		subject.NumberOfUnitsShipped = 4;
		subject.QuantityDifference = 5;
		subject.UnitOfMeasurementCode = "YD";
		//Test Parameters
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "o3";
		subject.NumberOfUnitsShipped = 4;
		subject.QuantityDifference = 5;
		subject.UnitOfMeasurementCode = "YD";
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "o3";
		subject.QuantityOrdered = 5;
		subject.QuantityDifference = 5;
		subject.UnitOfMeasurementCode = "YD";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityDifference(decimal quantityDifference, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "o3";
		subject.QuantityOrdered = 5;
		subject.NumberOfUnitsShipped = 4;
		subject.UnitOfMeasurementCode = "YD";
		//Test Parameters
		if (quantityDifference > 0) 
			subject.QuantityDifference = quantityDifference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YD", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "o3";
		subject.QuantityOrdered = 5;
		subject.NumberOfUnitsShipped = 4;
		subject.QuantityDifference = 5;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
