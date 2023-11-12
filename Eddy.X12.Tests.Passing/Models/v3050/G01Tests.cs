using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G01*7qpIRy*5*O4mth4*x*f*8*889979*PG";

		var expected = new G01_InvoiceIdentification()
		{
			Date = "7qpIRy",
			InvoiceNumber = "5",
			Date2 = "O4mth4",
			PurchaseOrderNumber = "x",
			VendorOrderNumber = "f",
			MasterReferenceLinkNumber = "8",
			LinkSequenceNumber = 889979,
			TransactionTypeCode = "PG",
		};

		var actual = Map.MapObject<G01_InvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7qpIRy", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceNumber = "5";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "8";
			subject.LinkSequenceNumber = 889979;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.Date = "7qpIRy";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "8";
			subject.LinkSequenceNumber = 889979;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("8", 889979, true)]
	[InlineData("8", 0, false)]
	[InlineData("", 889979, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.Date = "7qpIRy";
		subject.InvoiceNumber = "5";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
