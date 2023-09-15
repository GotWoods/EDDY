using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEG*4S*UH*F*J*YKHdIBO4*Y*d2*YdO*2Y*D9*ha*Q7";

		var expected = new BEG_BeginningSegmentForPurchaseOrder()
		{
			TransactionSetPurposeCode = "4S",
			PurchaseOrderTypeCode = "UH",
			PurchaseOrderNumber = "F",
			ReleaseNumber = "J",
			Date = "YKHdIBO4",
			ContractNumber = "Y",
			AcknowledgmentTypeCode = "d2",
			InvoiceTypeCode = "YdO",
			ContractTypeCode = "2Y",
			PurchaseCategoryCode = "D9",
			SecurityLevelCode = "ha",
			TransactionTypeCode = "Q7",
		};

		var actual = Map.MapObject<BEG_BeginningSegmentForPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4S", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.PurchaseOrderTypeCode = "UH";
		subject.PurchaseOrderNumber = "F";
		subject.Date = "YKHdIBO4";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UH", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "4S";
		subject.PurchaseOrderNumber = "F";
		subject.Date = "YKHdIBO4";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "4S";
		subject.PurchaseOrderTypeCode = "UH";
		subject.Date = "YKHdIBO4";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YKHdIBO4", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "4S";
		subject.PurchaseOrderTypeCode = "UH";
		subject.PurchaseOrderNumber = "F";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
