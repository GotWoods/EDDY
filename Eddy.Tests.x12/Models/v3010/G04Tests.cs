using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G04*TY*4*7*6*zu*AUpHnCFwq1SY*aD*O";

		var expected = new G04_ItemDetail()
		{
			ShipmentOrderStatusCode = "TY",
			QuantityOrdered = 4,
			NumberOfUnitsShipped = 7,
			QuantityDifference = 6,
			UnitOfMeasurementCode = "zu",
			UPCCaseCode = "AUpHnCFwq1SY",
			ProductServiceIDQualifier = "aD",
			ProductServiceID = "O",
		};

		var actual = Map.MapObject<G04_ItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TY", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.QuantityOrdered = 4;
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 6;
		subject.UnitOfMeasurementCode = "zu";
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "TY";
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 6;
		subject.UnitOfMeasurementCode = "zu";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "TY";
		subject.QuantityOrdered = 4;
		subject.QuantityDifference = 6;
		subject.UnitOfMeasurementCode = "zu";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityDifference(decimal quantityDifference, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "TY";
		subject.QuantityOrdered = 4;
		subject.NumberOfUnitsShipped = 7;
		subject.UnitOfMeasurementCode = "zu";
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zu", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G04_ItemDetail();
		subject.ShipmentOrderStatusCode = "TY";
		subject.QuantityOrdered = 4;
		subject.NumberOfUnitsShipped = 7;
		subject.QuantityDifference = 6;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
