using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W12*n2*7*7*4*Cm*BGwtz805aJbQ*0m*j*g*6*E*S*4*K*P*XMinJUEeFqnn*Gx*r*VU*k";

		var expected = new W12_WarehouseItemDetail()
		{
			ShipmentOrderStatusCode = "n2",
			QuantityOrdered = 7,
			NumberOfUnitsShipped = 7,
			QuantityDifference = 4,
			UnitOrBasisForMeasurementCode = "Cm",
			UPCCaseCode = "BGwtz805aJbQ",
			ProductServiceIDQualifier = "0m",
			ProductServiceID = "j",
			WarehouseLotNumber = "g",
			Weight = 6,
			WeightQualifier = "E",
			WeightUnitCode = "S",
			Weight2 = 4,
			WeightQualifier2 = "K",
			WeightUnitCode2 = "P",
			UPCCaseCode2 = "XMinJUEeFqnn",
			ProductServiceIDQualifier2 = "Gx",
			ProductServiceID2 = "r",
			LineItemChangeReasonCode = "VU",
			WarehouseDetailAdjustmentIdentifier = "k",
		};

		var actual = Map.MapObject<W12_WarehouseItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n2", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		//Test Parameters
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		//At Least one
		subject.UPCCaseCode = "BGwtz805aJbQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "0m";
			subject.ProductServiceID = "j";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Gx";
			subject.ProductServiceID2 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("BGwtz805aJbQ", "0m", true)]
	[InlineData("BGwtz805aJbQ", "", true)]
	[InlineData("", "0m", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "n2";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "0m";
			subject.ProductServiceID = "j";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Gx";
			subject.ProductServiceID2 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0m", "j", true)]
	[InlineData("0m", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "n2";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "BGwtz805aJbQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Gx";
			subject.ProductServiceID2 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gx", "r", true)]
	[InlineData("Gx", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "n2";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "BGwtz805aJbQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "0m";
			subject.ProductServiceID = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
