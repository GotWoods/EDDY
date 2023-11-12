using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G11*LL0xnV*5*94CYEW*u*U*Od*g";

		var expected = new G11_AdjustmentIdentification()
		{
			InvoiceDate = "LL0xnV",
			InvoiceNumber = "5",
			PurchaseOrderDate = "94CYEW",
			PurchaseOrderNumber = "u",
			VendorOrderNumber = "U",
			ReferenceNumberQualifier = "Od",
			ReferenceNumber = "g",
		};

		var actual = Map.MapObject<G11_AdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LL0xnV", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new G11_AdjustmentIdentification();
		subject.InvoiceNumber = "5";
		subject.PurchaseOrderDate = "94CYEW";
		subject.InvoiceDate = invoiceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G11_AdjustmentIdentification();
		subject.InvoiceDate = "LL0xnV";
		subject.PurchaseOrderDate = "94CYEW";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("94CYEW", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new G11_AdjustmentIdentification();
		subject.InvoiceDate = "LL0xnV";
		subject.InvoiceNumber = "5";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
