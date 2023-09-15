using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G01*vdkgYX*6*cVMq1l*7*L*d*357115";

		var expected = new G01_InvoiceIdentification()
		{
			InvoiceDate = "vdkgYX",
			InvoiceNumber = "6",
			PurchaseOrderDate = "cVMq1l",
			PurchaseOrderNumber = "7",
			VendorOrderNumber = "L",
			MasterReferenceLinkNumber = "d",
			LinkSequenceNumber = 357115,
		};

		var actual = Map.MapObject<G01_InvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vdkgYX", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceNumber = "6";
		subject.PurchaseOrderDate = "cVMq1l";
		subject.PurchaseOrderNumber = "7";
		subject.InvoiceDate = invoiceDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "d";
			subject.LinkSequenceNumber = 357115;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "vdkgYX";
		subject.PurchaseOrderDate = "cVMq1l";
		subject.PurchaseOrderNumber = "7";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "d";
			subject.LinkSequenceNumber = 357115;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cVMq1l", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "vdkgYX";
		subject.InvoiceNumber = "6";
		subject.PurchaseOrderNumber = "7";
		subject.PurchaseOrderDate = purchaseOrderDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "d";
			subject.LinkSequenceNumber = 357115;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "vdkgYX";
		subject.InvoiceNumber = "6";
		subject.PurchaseOrderDate = "cVMq1l";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "d";
			subject.LinkSequenceNumber = 357115;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("d", 357115, true)]
	[InlineData("d", 0, false)]
	[InlineData("", 357115, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "vdkgYX";
		subject.InvoiceNumber = "6";
		subject.PurchaseOrderDate = "cVMq1l";
		subject.PurchaseOrderNumber = "7";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
