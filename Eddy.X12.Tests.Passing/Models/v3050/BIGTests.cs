using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BIGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIG*F6APc3*J*id6IEO*A*B*1*jS*b9*A*5";

		var expected = new BIG_BeginningSegmentForInvoice()
		{
			Date = "F6APc3",
			InvoiceNumber = "J",
			Date2 = "id6IEO",
			PurchaseOrderNumber = "A",
			ReleaseNumber = "B",
			ChangeOrderSequenceNumber = "1",
			TransactionTypeCode = "jS",
			TransactionSetPurposeCode = "b9",
			ActionCode = "A",
			InvoiceNumber2 = "5",
		};

		var actual = Map.MapObject<BIG_BeginningSegmentForInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F6APc3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceNumber = "J";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.Date = "F6APc3";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
