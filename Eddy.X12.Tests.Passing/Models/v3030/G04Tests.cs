using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G04*H0*3*8*1*fw*hnk6KCjWKwCx*vJ*W";

		var expected = new G04_ItemDetail()
		{
			ShipmentOrderStatusCode = "H0",
			QuantityOrdered = 3,
			NumberOfUnitsShipped = 8,
			QuantityDifference = 1,
			UnitOrBasisForMeasurementCode = "fw",
			UPCCaseCode = "hnk6KCjWKwCx",
			ProductServiceIDQualifier = "vJ",
			ProductServiceID = "W",
		};

		var actual = Map.MapObject<G04_ItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H0", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.QuantityOrdered = 3;
		subject.NumberOfUnitsShipped = 8;
		subject.QuantityDifference = 1;
		subject.UnitOrBasisForMeasurementCode = "fw";
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
			subject.UPCCaseCode = "hnk6KCjWKwCx";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vJ";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "H0";
		subject.NumberOfUnitsShipped = 8;
		subject.QuantityDifference = 1;
		subject.UnitOrBasisForMeasurementCode = "fw";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
			subject.UPCCaseCode = "hnk6KCjWKwCx";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vJ";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "H0";
		subject.QuantityOrdered = 3;
		subject.QuantityDifference = 1;
		subject.UnitOrBasisForMeasurementCode = "fw";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
			subject.UPCCaseCode = "hnk6KCjWKwCx";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vJ";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityDifference(decimal quantityDifference, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "H0";
		subject.QuantityOrdered = 3;
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "fw";
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
			subject.UPCCaseCode = "hnk6KCjWKwCx";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vJ";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fw", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "H0";
		subject.QuantityOrdered = 3;
		subject.NumberOfUnitsShipped = 8;
		subject.QuantityDifference = 1;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "hnk6KCjWKwCx";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vJ";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("hnk6KCjWKwCx", "vJ", true)]
	[InlineData("hnk6KCjWKwCx", "", true)]
	[InlineData("", "vJ", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "H0";
		subject.QuantityOrdered = 3;
		subject.NumberOfUnitsShipped = 8;
		subject.QuantityDifference = 1;
		subject.UnitOrBasisForMeasurementCode = "fw";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vJ";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vJ", "W", true)]
	[InlineData("vJ", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "H0";
		subject.QuantityOrdered = 3;
		subject.NumberOfUnitsShipped = 8;
		subject.QuantityDifference = 1;
		subject.UnitOrBasisForMeasurementCode = "fw";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "hnk6KCjWKwCx";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
