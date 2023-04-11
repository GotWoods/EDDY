using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BAKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAK*61*p2*t*MKNC1ldw*Z*s*M*1*3iV17mhU*vc";

		var expected = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment()
		{
			TransactionSetPurposeCode = "61",
			AcknowledgmentTypeCode = "p2",
			PurchaseOrderNumber = "t",
			Date = "MKNC1ldw",
			ReleaseNumber = "Z",
			RequestReferenceNumber = "s",
			ContractNumber = "M",
			ReferenceIdentification = "1",
			Date2 = "3iV17mhU",
			TransactionTypeCode = "vc",
		};

		var actual = Map.MapObject<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("61", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.AcknowledgmentTypeCode = "p2";
		subject.PurchaseOrderNumber = "t";
		subject.Date = "MKNC1ldw";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p2", true)]
	public void Validatation_RequiredAcknowledgmentTypeCode(string acknowledgmentTypeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "61";
		subject.PurchaseOrderNumber = "t";
		subject.Date = "MKNC1ldw";
		subject.AcknowledgmentTypeCode = acknowledgmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validatation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "61";
		subject.AcknowledgmentTypeCode = "p2";
		subject.Date = "MKNC1ldw";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MKNC1ldw", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "61";
		subject.AcknowledgmentTypeCode = "p2";
		subject.PurchaseOrderNumber = "t";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
