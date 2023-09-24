using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G01*WWK0kveC*2*hNFZ35RQ*A*v*G*648262*IG";

		var expected = new G01_InvoiceIdentification()
		{
			Date = "WWK0kveC",
			InvoiceNumber = "2",
			Date2 = "hNFZ35RQ",
			PurchaseOrderNumber = "A",
			VendorOrderNumber = "v",
			MasterReferenceLinkNumber = "G",
			LinkSequenceNumber = 648262,
			TransactionTypeCode = "IG",
		};

		var actual = Map.MapObject<G01_InvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WWK0kveC", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceNumber = "2";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "G";
			subject.LinkSequenceNumber = 648262;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.Date = "WWK0kveC";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "G";
			subject.LinkSequenceNumber = 648262;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("G", 648262, true)]
	[InlineData("G", 0, false)]
	[InlineData("", 648262, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.Date = "WWK0kveC";
		subject.InvoiceNumber = "2";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
