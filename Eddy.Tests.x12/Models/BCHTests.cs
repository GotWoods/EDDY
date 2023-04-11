using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*Hi*tu*P*t*x*2EAGCygq*A*p*d*Vy5EIs8a*9yvcWOo5*ym*Jy*Ys*qb*pG";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "Hi",
			PurchaseOrderTypeCode = "tu",
			PurchaseOrderNumber = "P",
			ReleaseNumber = "t",
			ChangeOrderSequenceNumber = "x",
			Date = "2EAGCygq",
			RequestReferenceNumber = "A",
			ContractNumber = "p",
			ReferenceIdentification = "d",
			Date2 = "Vy5EIs8a",
			Date3 = "9yvcWOo5",
			ContractTypeCode = "ym",
			SecurityLevelCode = "Jy",
			AcknowledgmentTypeCode = "Ys",
			TransactionTypeCode = "qb",
			PurchaseCategoryCode = "pG",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hi", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "tu";
		subject.PurchaseOrderNumber = "P";
		subject.Date = "2EAGCygq";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tu", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "Hi";
		subject.PurchaseOrderNumber = "P";
		subject.Date = "2EAGCygq";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "Hi";
		subject.PurchaseOrderTypeCode = "tu";
		subject.Date = "2EAGCygq";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2EAGCygq", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "Hi";
		subject.PurchaseOrderTypeCode = "tu";
		subject.PurchaseOrderNumber = "P";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
