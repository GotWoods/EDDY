using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*nN*HH*e*0*6*imumZN*s*8*2*zsAfEo*UwjQ9z*8B*yN*Kj*P0*Qk";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "nN",
			PurchaseOrderTypeCode = "HH",
			PurchaseOrderNumber = "e",
			ReleaseNumber = "0",
			ChangeOrderSequenceNumber = "6",
			Date = "imumZN",
			RequestReferenceNumber = "s",
			ContractNumber = "8",
			ReferenceNumber = "2",
			Date2 = "zsAfEo",
			Date3 = "UwjQ9z",
			ContractTypeCode = "8B",
			SecurityLevelCode = "yN",
			AcknowledgmentType = "Kj",
			TransactionTypeCode = "P0",
			PurchaseCategory = "Qk",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nN", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "HH";
		subject.PurchaseOrderNumber = "e";
		subject.Date = "imumZN";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HH", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "nN";
		subject.PurchaseOrderNumber = "e";
		subject.Date = "imumZN";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "nN";
		subject.PurchaseOrderTypeCode = "HH";
		subject.Date = "imumZN";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("imumZN", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "nN";
		subject.PurchaseOrderTypeCode = "HH";
		subject.PurchaseOrderNumber = "e";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
