using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BIGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIG*oWMESp6s*K*yjIuULKz*6*0*l*6J*V5*0*D*oOjc";

		var expected = new BIG_BeginningSegmentForInvoice()
		{
			Date = "oWMESp6s",
			InvoiceNumber = "K",
			Date2 = "yjIuULKz",
			PurchaseOrderNumber = "6",
			ReleaseNumber = "0",
			ChangeOrderSequenceNumber = "l",
			TransactionTypeCode = "6J",
			TransactionSetPurposeCode = "V5",
			ActionCode = "0",
			InvoiceNumber2 = "D",
			HierarchicalStructureCode = "oOjc",
		};

		var actual = Map.MapObject<BIG_BeginningSegmentForInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oWMESp6s", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceNumber = "K";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.Date = "oWMESp6s";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
