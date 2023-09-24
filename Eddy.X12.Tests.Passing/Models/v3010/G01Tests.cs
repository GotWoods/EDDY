using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G01*dXg8x1*K*STaDBT*n*G*i*334474";

		var expected = new G01_InvoiceIdentification()
		{
			InvoiceDate = "dXg8x1",
			InvoiceNumber = "K",
			PurchaseOrderDate = "STaDBT",
			PurchaseOrderNumber = "n",
			VendorOrderNumber = "G",
			MasterReferenceLinkNumber = "i",
			LinkSequenceNumber = 334474,
		};

		var actual = Map.MapObject<G01_InvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dXg8x1", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceNumber = "K";
		subject.PurchaseOrderDate = "STaDBT";
		subject.PurchaseOrderNumber = "n";
		subject.InvoiceDate = invoiceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "dXg8x1";
		subject.PurchaseOrderDate = "STaDBT";
		subject.PurchaseOrderNumber = "n";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("STaDBT", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "dXg8x1";
		subject.InvoiceNumber = "K";
		subject.PurchaseOrderNumber = "n";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "dXg8x1";
		subject.InvoiceNumber = "K";
		subject.PurchaseOrderDate = "STaDBT";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
