using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*7r*42*u*O*h*730wmURF*R*A*u*yeqCMGXr*nQMEUzOm*sM*4K*wx*vn*7K";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "7r",
			PurchaseOrderTypeCode = "42",
			PurchaseOrderNumber = "u",
			ReleaseNumber = "O",
			ChangeOrderSequenceNumber = "h",
			Date = "730wmURF",
			RequestReferenceNumber = "R",
			ContractNumber = "A",
			ReferenceIdentification = "u",
			Date2 = "yeqCMGXr",
			Date3 = "nQMEUzOm",
			ContractTypeCode = "sM",
			SecurityLevelCode = "4K",
			AcknowledgmentType = "wx",
			TransactionTypeCode = "vn",
			PurchaseCategory = "7K",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7r", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "42";
		subject.PurchaseOrderNumber = "u";
		subject.Date = "730wmURF";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("42", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "7r";
		subject.PurchaseOrderNumber = "u";
		subject.Date = "730wmURF";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "7r";
		subject.PurchaseOrderTypeCode = "42";
		subject.Date = "730wmURF";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("730wmURF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "7r";
		subject.PurchaseOrderTypeCode = "42";
		subject.PurchaseOrderNumber = "u";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
