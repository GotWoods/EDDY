using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BIGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIG*aGrMe9*a*S173lD*N*T*r*9D";

		var expected = new BIG_BeginningSegmentForInvoice()
		{
			InvoiceDate = "aGrMe9",
			InvoiceNumber = "a",
			PurchaseOrderDate = "S173lD",
			PurchaseOrderNumber = "N",
			ReleaseNumber = "T",
			ChangeOrderSequenceNumber = "r",
			TransactionTypeCode = "9D",
		};

		var actual = Map.MapObject<BIG_BeginningSegmentForInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aGrMe9", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceNumber = "a";
		subject.InvoiceDate = invoiceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceDate = "aGrMe9";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
