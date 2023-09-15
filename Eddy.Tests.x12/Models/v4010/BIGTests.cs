using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BIGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIG*reW9KX8A*4*X2lzG0zY*i*G*G*xl*ZX*h*N";

		var expected = new BIG_BeginningSegmentForInvoice()
		{
			Date = "reW9KX8A",
			InvoiceNumber = "4",
			Date2 = "X2lzG0zY",
			PurchaseOrderNumber = "i",
			ReleaseNumber = "G",
			ChangeOrderSequenceNumber = "G",
			TransactionTypeCode = "xl",
			TransactionSetPurposeCode = "ZX",
			ActionCode = "h",
			InvoiceNumber2 = "N",
		};

		var actual = Map.MapObject<BIG_BeginningSegmentForInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("reW9KX8A", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.InvoiceNumber = "4";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BIG_BeginningSegmentForInvoice();
		subject.Date = "reW9KX8A";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
