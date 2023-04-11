using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BIGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIG*6q8xQllD*1*MIgpYI57*H*y*m*CI*Di*z*g*oPSp";

		var expected = new BIG_BeginningSegmentForInvoice()
		{
			Date = "6q8xQllD",
			InvoiceNumber = "1",
			Date2 = "MIgpYI57",
			PurchaseOrderNumber = "H",
			ReleaseNumber = "y",
			ChangeOrderSequenceNumber = "m",
			TransactionTypeCode = "CI",
			TransactionSetPurposeCode = "Di",
			ActionCode = "z",
			InvoiceNumber2 = "g",
			HierarchicalStructureCode = "oPSp",
		};

		var actual = Map.MapObject<BIG_BeginningSegmentForInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6q8xQllD", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceNumber = "1";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validatation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.Date = "6q8xQllD";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
