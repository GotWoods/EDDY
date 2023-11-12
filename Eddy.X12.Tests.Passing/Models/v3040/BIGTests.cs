using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BIGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIG*es5WRn*e*7U8YaJ*v*y*U*wn*im*x*M";

		var expected = new BIG_BeginningSegmentForInvoice()
		{
			InvoiceDate = "es5WRn",
			InvoiceNumber = "e",
			PurchaseOrderDate = "7U8YaJ",
			PurchaseOrderNumber = "v",
			ReleaseNumber = "y",
			ChangeOrderSequenceNumber = "U",
			TransactionTypeCode = "wn",
			TransactionSetPurposeCode = "im",
			ActionCode = "x",
			InvoiceNumber2 = "M",
		};

		var actual = Map.MapObject<BIG_BeginningSegmentForInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("es5WRn", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceNumber = "e";
		subject.InvoiceDate = invoiceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceDate = "es5WRn";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
