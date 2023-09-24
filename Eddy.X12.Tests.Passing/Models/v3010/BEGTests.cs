using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEG*tq*Mq*2*8*RrYEPf*Q*or";

		var expected = new BEG_BeginningSegmentForPurchaseOrder()
		{
			TransactionSetPurposeCode = "tq",
			PurchaseOrderTypeCode = "Mq",
			PurchaseOrderNumber = "2",
			ReleaseNumber = "8",
			PurchaseOrderDate = "RrYEPf",
			ContractNumber = "Q",
			AcknowledgmentType = "or",
		};

		var actual = Map.MapObject<BEG_BeginningSegmentForPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tq", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.PurchaseOrderTypeCode = "Mq";
		subject.PurchaseOrderNumber = "2";
		subject.PurchaseOrderDate = "RrYEPf";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mq", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "tq";
		subject.PurchaseOrderNumber = "2";
		subject.PurchaseOrderDate = "RrYEPf";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "tq";
		subject.PurchaseOrderTypeCode = "Mq";
		subject.PurchaseOrderDate = "RrYEPf";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RrYEPf", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "tq";
		subject.PurchaseOrderTypeCode = "Mq";
		subject.PurchaseOrderNumber = "2";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
