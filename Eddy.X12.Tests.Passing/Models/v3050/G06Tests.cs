using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G06*S*narFIk*t*X";

		var expected = new G06_ReceivingIdentification()
		{
			VendorOrderNumber = "S",
			Date = "narFIk",
			ShipmentIdentificationNumber = "t",
			PurchaseOrderNumber = "X",
		};

		var actual = Map.MapObject<G06_ReceivingIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredVendorOrderNumber(string vendorOrderNumber, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.Date = "narFIk";
		subject.ShipmentIdentificationNumber = "t";
		subject.PurchaseOrderNumber = "X";
		subject.VendorOrderNumber = vendorOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("narFIk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.VendorOrderNumber = "S";
		subject.ShipmentIdentificationNumber = "t";
		subject.PurchaseOrderNumber = "X";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.VendorOrderNumber = "S";
		subject.Date = "narFIk";
		subject.PurchaseOrderNumber = "X";
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G06_ReceivingIdentification();
		subject.VendorOrderNumber = "S";
		subject.Date = "narFIk";
		subject.ShipmentIdentificationNumber = "t";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
