using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G11*NNIBrW*y*8RjTXz*i*y*DM*q";

		var expected = new G11_AdjustmentIdentification()
		{
			InvoiceDate = "NNIBrW",
			InvoiceNumber = "y",
			PurchaseOrderDate = "8RjTXz",
			PurchaseOrderNumber = "i",
			VendorOrderNumber = "y",
			ReferenceNumberQualifier = "DM",
			ReferenceNumber = "q",
		};

		var actual = Map.MapObject<G11_AdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NNIBrW", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new G11_AdjustmentIdentification();
		subject.InvoiceNumber = "y";
		subject.PurchaseOrderDate = "8RjTXz";
		subject.InvoiceDate = invoiceDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "DM";
			subject.ReferenceNumber = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G11_AdjustmentIdentification();
		subject.InvoiceDate = "NNIBrW";
		subject.PurchaseOrderDate = "8RjTXz";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "DM";
			subject.ReferenceNumber = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8RjTXz", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new G11_AdjustmentIdentification();
		subject.InvoiceDate = "NNIBrW";
		subject.InvoiceNumber = "y";
		subject.PurchaseOrderDate = purchaseOrderDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "DM";
			subject.ReferenceNumber = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DM", "q", true)]
	[InlineData("DM", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new G11_AdjustmentIdentification();
		subject.InvoiceDate = "NNIBrW";
		subject.InvoiceNumber = "y";
		subject.PurchaseOrderDate = "8RjTXz";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
