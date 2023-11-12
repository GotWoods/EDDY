using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G02*s*jzzYZT*V*e*y";

		var expected = new G02_ShipmentIdentification()
		{
			VendorOrderNumber = "s",
			ShipmentDate = "jzzYZT",
			ShipmentIdentificationNumber = "V",
			PurchaseOrderNumber = "e",
			MasterReferenceLinkNumber = "y",
		};

		var actual = Map.MapObject<G02_ShipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredVendorOrderNumber(string vendorOrderNumber, bool isValidExpected)
	{
		var subject = new G02_ShipmentIdentification();
		subject.ShipmentDate = "jzzYZT";
		subject.ShipmentIdentificationNumber = "V";
		subject.PurchaseOrderNumber = "e";
		subject.VendorOrderNumber = vendorOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jzzYZT", true)]
	public void Validation_RequiredShipmentDate(string shipmentDate, bool isValidExpected)
	{
		var subject = new G02_ShipmentIdentification();
		subject.VendorOrderNumber = "s";
		subject.ShipmentIdentificationNumber = "V";
		subject.PurchaseOrderNumber = "e";
		subject.ShipmentDate = shipmentDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new G02_ShipmentIdentification();
		subject.VendorOrderNumber = "s";
		subject.ShipmentDate = "jzzYZT";
		subject.PurchaseOrderNumber = "e";
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G02_ShipmentIdentification();
		subject.VendorOrderNumber = "s";
		subject.ShipmentDate = "jzzYZT";
		subject.ShipmentIdentificationNumber = "V";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
