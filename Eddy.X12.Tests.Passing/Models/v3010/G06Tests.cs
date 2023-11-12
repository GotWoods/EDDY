using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G06*M*oYrcRK*c*A";

		var expected = new G06_ReceivingIdentification()
		{
			VendorOrderNumber = "M",
			DeliveryDate = "oYrcRK",
			ShipmentIdentificationNumber = "c",
			PurchaseOrderNumber = "A",
		};

		var actual = Map.MapObject<G06_ReceivingIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredVendorOrderNumber(string vendorOrderNumber, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.DeliveryDate = "oYrcRK";
		subject.ShipmentIdentificationNumber = "c";
		subject.PurchaseOrderNumber = "A";
		subject.VendorOrderNumber = vendorOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oYrcRK", true)]
	public void Validation_RequiredDeliveryDate(string deliveryDate, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.VendorOrderNumber = "M";
		subject.ShipmentIdentificationNumber = "c";
		subject.PurchaseOrderNumber = "A";
		subject.DeliveryDate = deliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.VendorOrderNumber = "M";
		subject.DeliveryDate = "oYrcRK";
		subject.PurchaseOrderNumber = "A";
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.VendorOrderNumber = "M";
		subject.DeliveryDate = "oYrcRK";
		subject.ShipmentIdentificationNumber = "c";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
