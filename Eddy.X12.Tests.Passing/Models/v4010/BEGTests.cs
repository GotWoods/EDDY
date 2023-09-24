using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEG*7P*pf*a*2*cVWwAj6J*E*wX*WcE*3d*OM*sd*vc";

		var expected = new BEG_BeginningSegmentForPurchaseOrder()
		{
			TransactionSetPurposeCode = "7P",
			PurchaseOrderTypeCode = "pf",
			PurchaseOrderNumber = "a",
			ReleaseNumber = "2",
			Date = "cVWwAj6J",
			ContractNumber = "E",
			AcknowledgmentType = "wX",
			InvoiceTypeCode = "WcE",
			ContractTypeCode = "3d",
			PurchaseCategory = "OM",
			SecurityLevelCode = "sd",
			TransactionTypeCode = "vc",
		};

		var actual = Map.MapObject<BEG_BeginningSegmentForPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7P", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.PurchaseOrderTypeCode = "pf";
		subject.PurchaseOrderNumber = "a";
		subject.Date = "cVWwAj6J";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pf", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "7P";
		subject.PurchaseOrderNumber = "a";
		subject.Date = "cVWwAj6J";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "7P";
		subject.PurchaseOrderTypeCode = "pf";
		subject.Date = "cVWwAj6J";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cVWwAj6J", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "7P";
		subject.PurchaseOrderTypeCode = "pf";
		subject.PurchaseOrderNumber = "a";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
