using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*WJ*mD*J*j*4*dxD7FhJZ*R*7*z*smahZ41U*IuCVYcvk*C4*JP*aG*oT*oY";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "WJ",
			PurchaseOrderTypeCode = "mD",
			PurchaseOrderNumber = "J",
			ReleaseNumber = "j",
			ChangeOrderSequenceNumber = "4",
			Date = "dxD7FhJZ",
			RequestReferenceNumber = "R",
			ContractNumber = "7",
			ReferenceIdentification = "z",
			Date2 = "smahZ41U",
			Date3 = "IuCVYcvk",
			ContractTypeCode = "C4",
			SecurityLevelCode = "JP",
			AcknowledgmentTypeCode = "aG",
			TransactionTypeCode = "oT",
			PurchaseCategoryCode = "oY",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WJ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "mD";
		subject.PurchaseOrderNumber = "J";
		subject.Date = "dxD7FhJZ";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mD", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "WJ";
		subject.PurchaseOrderNumber = "J";
		subject.Date = "dxD7FhJZ";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "WJ";
		subject.PurchaseOrderTypeCode = "mD";
		subject.Date = "dxD7FhJZ";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dxD7FhJZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "WJ";
		subject.PurchaseOrderTypeCode = "mD";
		subject.PurchaseOrderNumber = "J";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
