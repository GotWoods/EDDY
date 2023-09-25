using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W12*vL*2*1*8*Kr*9cC4U1R7DmId*Eu*q*M*7*9*z*2*e*3*7FgQrhUyb7hv*sx*s*Bi*y";

		var expected = new W12_WarehouseItemDetail()
		{
			ShipmentOrderStatusCode = "vL",
			QuantityOrdered = 2,
			NumberOfUnitsShipped = 1,
			QuantityDifference = 8,
			UnitOfMeasurementCode = "Kr",
			UPCCaseCode = "9cC4U1R7DmId",
			ProductServiceIDQualifier = "Eu",
			ProductServiceID = "q",
			WarehouseLotNumber = "M",
			Weight = 7,
			WeightQualifier = "9",
			WeightUnitQualifier = "z",
			Weight2 = 2,
			WeightQualifier2 = "e",
			WeightUnitQualifier2 = "3",
			UPCCaseCode2 = "7FgQrhUyb7hv",
			ProductServiceIDQualifier2 = "sx",
			ProductServiceID2 = "s",
			LineItemChangeReasonCode = "Bi",
			WarehouseDetailAdjustmentIdentifier = "y",
		};

		var actual = Map.MapObject<W12_WarehouseItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vL", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.QuantityOrdered = 2;
		subject.NumberOfUnitsShipped = 1;
		subject.QuantityDifference = 8;
		subject.UnitOfMeasurementCode = "Kr";
		//Test Parameters
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		//At Least one
		subject.UPCCaseCode = "9cC4U1R7DmId";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eu";
			subject.ProductServiceID = "q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "sx";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "vL";
		subject.NumberOfUnitsShipped = 1;
		subject.QuantityDifference = 8;
		subject.UnitOfMeasurementCode = "Kr";
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		//At Least one
		subject.UPCCaseCode = "9cC4U1R7DmId";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eu";
			subject.ProductServiceID = "q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "sx";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "vL";
		subject.QuantityOrdered = 2;
		subject.QuantityDifference = 8;
		subject.UnitOfMeasurementCode = "Kr";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//At Least one
		subject.UPCCaseCode = "9cC4U1R7DmId";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eu";
			subject.ProductServiceID = "q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "sx";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantityDifference(decimal quantityDifference, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "vL";
		subject.QuantityOrdered = 2;
		subject.NumberOfUnitsShipped = 1;
		subject.UnitOfMeasurementCode = "Kr";
		//Test Parameters
		if (quantityDifference > 0) 
			subject.QuantityDifference = quantityDifference;
		//At Least one
		subject.UPCCaseCode = "9cC4U1R7DmId";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eu";
			subject.ProductServiceID = "q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "sx";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kr", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "vL";
		subject.QuantityOrdered = 2;
		subject.NumberOfUnitsShipped = 1;
		subject.QuantityDifference = 8;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "9cC4U1R7DmId";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eu";
			subject.ProductServiceID = "q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "sx";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9cC4U1R7DmId", "Eu", true)]
	[InlineData("9cC4U1R7DmId", "", true)]
	[InlineData("", "Eu", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "vL";
		subject.QuantityOrdered = 2;
		subject.NumberOfUnitsShipped = 1;
		subject.QuantityDifference = 8;
		subject.UnitOfMeasurementCode = "Kr";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eu";
			subject.ProductServiceID = "q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "sx";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Eu", "q", true)]
	[InlineData("Eu", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "vL";
		subject.QuantityOrdered = 2;
		subject.NumberOfUnitsShipped = 1;
		subject.QuantityDifference = 8;
		subject.UnitOfMeasurementCode = "Kr";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "9cC4U1R7DmId";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "sx";
			subject.ProductServiceID2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sx", "s", true)]
	[InlineData("sx", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W12_WarehouseItemDetail();
		//Required fields
		subject.ShipmentOrderStatusCode = "vL";
		subject.QuantityOrdered = 2;
		subject.NumberOfUnitsShipped = 1;
		subject.QuantityDifference = 8;
		subject.UnitOfMeasurementCode = "Kr";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "9cC4U1R7DmId";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eu";
			subject.ProductServiceID = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
