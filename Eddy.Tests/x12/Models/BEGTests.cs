using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEG*5N*nC*7*E*DzIEG8Ug*u*rc*RkD*MG*kR*Pg*nY";

		var expected = new BEG_BeginningSegmentForPurchaseOrder()
		{
			TransactionSetPurposeCode = "5N",
			PurchaseOrderTypeCode = "nC",
			PurchaseOrderNumber = "7",
			ReleaseNumber = "E",
			Date = "DzIEG8Ug",
			ContractNumber = "u",
			AcknowledgmentTypeCode = "rc",
			InvoiceTypeCode = "RkD",
			ContractTypeCode = "MG",
			PurchaseCategoryCode = "kR",
			SecurityLevelCode = "Pg",
			TransactionTypeCode = "nY",
		};

		var actual = Map.MapObject<BEG_BeginningSegmentForPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5N", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.PurchaseOrderTypeCode = "nC";
		subject.PurchaseOrderNumber = "7";
		subject.Date = "DzIEG8Ug";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nC", true)]
	public void Validatation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "5N";
		subject.PurchaseOrderNumber = "7";
		subject.Date = "DzIEG8Ug";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validatation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "5N";
		subject.PurchaseOrderTypeCode = "nC";
		subject.Date = "DzIEG8Ug";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DzIEG8Ug", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BEG_BeginningSegmentForPurchaseOrder();
		subject.TransactionSetPurposeCode = "5N";
		subject.PurchaseOrderTypeCode = "nC";
		subject.PurchaseOrderNumber = "7";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
