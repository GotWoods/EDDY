using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEG*fs*bU*t*j*W8K8xe*A*6w*XX0";

		var expected = new BEG_BeginningSegmentForPurchaseOrder()
		{
			TransactionSetPurposeCode = "fs",
			PurchaseOrderTypeCode = "bU",
			PurchaseOrderNumber = "t",
			ReleaseNumber = "j",
			PurchaseOrderDate = "W8K8xe",
			ContractNumber = "A",
			AcknowledgmentType = "6w",
			InvoiceTypeCode = "XX0",
		};

		var actual = Map.MapObject<BEG_BeginningSegmentForPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fs", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.PurchaseOrderTypeCode = "bU";
		subject.PurchaseOrderNumber = "t";
		subject.PurchaseOrderDate = "W8K8xe";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bU", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "fs";
		subject.PurchaseOrderNumber = "t";
		subject.PurchaseOrderDate = "W8K8xe";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "fs";
		subject.PurchaseOrderTypeCode = "bU";
		subject.PurchaseOrderDate = "W8K8xe";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W8K8xe", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "fs";
		subject.PurchaseOrderTypeCode = "bU";
		subject.PurchaseOrderNumber = "t";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
