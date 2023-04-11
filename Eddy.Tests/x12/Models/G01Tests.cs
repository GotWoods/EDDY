using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G01*CafwvhlL*e*ogNN1rXD*h*h*I*331248*0J";

		var expected = new G01_InvoiceIdentification()
		{
			Date = "CafwvhlL",
			InvoiceNumber = "e",
			Date2 = "ogNN1rXD",
			PurchaseOrderNumber = "h",
			VendorOrderNumber = "h",
			MasterReferenceLinkNumber = "I",
			LinkSequenceNumber = 331248,
			TransactionTypeCode = "0J",
		};

		var actual = Map.MapObject<G01_InvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CafwvhlL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceNumber = "e";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.Date = "CafwvhlL";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("I", 331248, true)]
	[InlineData("", 331248, false)]
	[InlineData("I", 0, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.Date = "CafwvhlL";
		subject.InvoiceNumber = "e";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
		subject.LinkSequenceNumber = linkSequenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
