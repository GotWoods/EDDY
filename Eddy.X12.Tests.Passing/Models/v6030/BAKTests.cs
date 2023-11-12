using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BAKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAK*K1*Wt*p*m8gxuK3n*h*W*K*C*bDK6y6Ke*dj";

		var expected = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment()
		{
			TransactionSetPurposeCode = "K1",
			AcknowledgmentTypeCode = "Wt",
			PurchaseOrderNumber = "p",
			Date = "m8gxuK3n",
			ReleaseNumber = "h",
			RequestReferenceNumber = "W",
			ContractNumber = "K",
			ReferenceIdentification = "C",
			Date2 = "bDK6y6Ke",
			TransactionTypeCode = "dj",
		};

		var actual = Map.MapObject<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K1", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.AcknowledgmentTypeCode = "Wt";
		subject.PurchaseOrderNumber = "p";
		subject.Date = "m8gxuK3n";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wt", true)]
	public void Validation_RequiredAcknowledgmentTypeCode(string acknowledgmentTypeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "K1";
		subject.PurchaseOrderNumber = "p";
		subject.Date = "m8gxuK3n";
		subject.AcknowledgmentTypeCode = acknowledgmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "K1";
		subject.AcknowledgmentTypeCode = "Wt";
		subject.Date = "m8gxuK3n";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m8gxuK3n", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "K1";
		subject.AcknowledgmentTypeCode = "Wt";
		subject.PurchaseOrderNumber = "p";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
