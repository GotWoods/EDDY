using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BAKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAK*TN*P4*C*rkvai3*p*Z*K*O*yzSvCt";

		var expected = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment()
		{
			TransactionSetPurposeCode = "TN",
			AcknowledgmentType = "P4",
			PurchaseOrderNumber = "C",
			Date = "rkvai3",
			ReleaseNumber = "p",
			RequestReferenceNumber = "Z",
			ContractNumber = "K",
			ReferenceIdentification = "O",
			Date2 = "yzSvCt",
		};

		var actual = Map.MapObject<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TN", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.AcknowledgmentType = "P4";
		subject.PurchaseOrderNumber = "C";
		subject.Date = "rkvai3";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P4", true)]
	public void Validation_RequiredAcknowledgmentType(string acknowledgmentType, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "TN";
		subject.PurchaseOrderNumber = "C";
		subject.Date = "rkvai3";
		subject.AcknowledgmentType = acknowledgmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "TN";
		subject.AcknowledgmentType = "P4";
		subject.Date = "rkvai3";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rkvai3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "TN";
		subject.AcknowledgmentType = "P4";
		subject.PurchaseOrderNumber = "C";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
