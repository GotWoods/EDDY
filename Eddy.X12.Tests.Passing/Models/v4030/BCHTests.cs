using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*7H*oj*u*A*E*YWlPzES2*x*A*7*ecRN4cPw*EgRzqTaT*uU*E0*QY*6M*nc";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "7H",
			PurchaseOrderTypeCode = "oj",
			PurchaseOrderNumber = "u",
			ReleaseNumber = "A",
			ChangeOrderSequenceNumber = "E",
			Date = "YWlPzES2",
			RequestReferenceNumber = "x",
			ContractNumber = "A",
			ReferenceIdentification = "7",
			Date2 = "ecRN4cPw",
			Date3 = "EgRzqTaT",
			ContractTypeCode = "uU",
			SecurityLevelCode = "E0",
			AcknowledgmentType = "QY",
			TransactionTypeCode = "6M",
			PurchaseCategory = "nc",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7H", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "oj";
		subject.PurchaseOrderNumber = "u";
		subject.Date = "YWlPzES2";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oj", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "7H";
		subject.PurchaseOrderNumber = "u";
		subject.Date = "YWlPzES2";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "7H";
		subject.PurchaseOrderTypeCode = "oj";
		subject.Date = "YWlPzES2";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YWlPzES2", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "7H";
		subject.PurchaseOrderTypeCode = "oj";
		subject.PurchaseOrderNumber = "u";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
