using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*GJ*3h*x*o*T*27F1RMmg*e*x*S*4QSoz5G8*JrZZkU7L*qc*k0*uU*17*en";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "GJ",
			PurchaseOrderTypeCode = "3h",
			PurchaseOrderNumber = "x",
			ReleaseNumber = "o",
			ChangeOrderSequenceNumber = "T",
			Date = "27F1RMmg",
			RequestReferenceNumber = "e",
			ContractNumber = "x",
			ReferenceIdentification = "S",
			Date2 = "4QSoz5G8",
			Date3 = "JrZZkU7L",
			ContractTypeCode = "qc",
			SecurityLevelCode = "k0",
			AcknowledgmentType = "uU",
			TransactionTypeCode = "17",
			PurchaseCategory = "en",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GJ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "3h";
		subject.PurchaseOrderNumber = "x";
		subject.Date = "27F1RMmg";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3h", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "GJ";
		subject.PurchaseOrderNumber = "x";
		subject.Date = "27F1RMmg";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "GJ";
		subject.PurchaseOrderTypeCode = "3h";
		subject.Date = "27F1RMmg";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("27F1RMmg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "GJ";
		subject.PurchaseOrderTypeCode = "3h";
		subject.PurchaseOrderNumber = "x";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
