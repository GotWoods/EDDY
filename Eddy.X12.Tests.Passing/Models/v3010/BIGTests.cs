using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BIGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIG*fu1Oan*S*jkUirM*2*0*C*kr";

		var expected = new BIG_BeginningSegmentForInvoice()
		{
			InvoiceDate = "fu1Oan",
			InvoiceNumber = "S",
			PurchaseOrderDate = "jkUirM",
			PurchaseOrderNumber = "2",
			ReleaseNumber = "0",
			ChangeOrderSequenceNumber = "C",
			TransactionTypeCode = "kr",
		};

		var actual = Map.MapObject<BIG_BeginningSegmentForInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fu1Oan", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceNumber = "S";
		subject.InvoiceDate = invoiceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceDate = "fu1Oan";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
