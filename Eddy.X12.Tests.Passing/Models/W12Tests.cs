using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W12*bw*7*6*5*xm*W0wqgdo3RBH9*kB*W*K*3*E*T*4*E*3*PGTDDkck5GaJ*Fj*1*jl*V*Uo*e";

		var expected = new W12_WarehouseItemDetail()
		{
			ShipmentOrderStatusCode = "bw",
			Quantity = 7,
			NumberOfUnitsShipped = 6,
			QuantityDifference = 5,
			UnitOrBasisForMeasurementCode = "xm",
			UPCCaseCode = "W0wqgdo3RBH9",
			ProductServiceIDQualifier = "kB",
			ProductServiceID = "W",
			WarehouseLotNumber = "K",
			Weight = 3,
			WeightQualifier = "E",
			WeightUnitCode = "T",
			Weight2 = 4,
			WeightQualifier2 = "E",
			WeightUnitCode2 = "3",
			UPCCaseCode2 = "PGTDDkck5GaJ",
			ProductServiceIDQualifier2 = "Fj",
			ProductServiceID2 = "1",
			LineItemChangeReasonCode = "jl",
			WarehouseDetailAdjustmentIdentifierCode = "V",
			ProductServiceIDQualifier3 = "Uo",
			ProductServiceID3 = "e",
		};

		var actual = Map.MapObject<W12_WarehouseItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bw", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("W0wqgdo3RBH9","kB", true)]
	[InlineData("", "kB", true)]
	[InlineData("W0wqgdo3RBH9", "", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		subject.ShipmentOrderStatusCode = "bw";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("kB", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("kB", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		subject.ShipmentOrderStatusCode = "bw";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Fj", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("Fj", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		subject.ShipmentOrderStatusCode = "bw";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Uo", "e", true)]
	[InlineData("", "e", false)]
	[InlineData("Uo", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		subject.ShipmentOrderStatusCode = "bw";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
