using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G04*Uc*7*7*9*3L*qUmvr2Pzpit1*jF*L";

		var expected = new G04_ItemDetail()
		{
			ShipmentOrderStatusCode = "Uc",
			QuantityOrdered = 7,
			NumberOfUnitsShipped = 7,
			QuantityDifference = 9,
			UnitOfMeasurementCode = "3L",
			UPCCaseCode = "qUmvr2Pzpit1",
			ProductServiceIDQualifier = "jF",
			ProductServiceID = "L",
		};

		var actual = Map.MapObject<G04_ItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uc", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.QuantityOrdered = 7;
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 9;
		subject.UnitOfMeasurementCode = "3L";
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
			subject.UPCCaseCode = "qUmvr2Pzpit1";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "jF";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "Uc";
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 9;
		subject.UnitOfMeasurementCode = "3L";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
			subject.UPCCaseCode = "qUmvr2Pzpit1";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "jF";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "Uc";
		subject.QuantityOrdered = 7;
		subject.QuantityDifference = 9;
		subject.UnitOfMeasurementCode = "3L";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
			subject.UPCCaseCode = "qUmvr2Pzpit1";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "jF";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantityDifference(decimal quantityDifference, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "Uc";
		subject.QuantityOrdered = 7;
		subject.NumberOfUnitsShipped = 7;
		subject.UnitOfMeasurementCode = "3L";
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
			subject.UPCCaseCode = "qUmvr2Pzpit1";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "jF";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3L", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "Uc";
		subject.QuantityOrdered = 7;
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 9;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UPCCaseCode = "qUmvr2Pzpit1";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "jF";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("qUmvr2Pzpit1", "jF", true)]
	[InlineData("qUmvr2Pzpit1", "", true)]
	[InlineData("", "jF", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "Uc";
		subject.QuantityOrdered = 7;
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 9;
		subject.UnitOfMeasurementCode = "3L";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "jF";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jF", "L", true)]
	[InlineData("jF", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "Uc";
		subject.QuantityOrdered = 7;
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 9;
		subject.UnitOfMeasurementCode = "3L";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "qUmvr2Pzpit1";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
