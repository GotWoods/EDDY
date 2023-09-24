using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BAKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAK*rB*sJ*l*VzqTz4*n*P*d*s*q2fDvY";

		var expected = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment()
		{
			TransactionSetPurposeCode = "rB",
			AcknowledgmentType = "sJ",
			PurchaseOrderNumber = "l",
			PurchaseOrderDate = "VzqTz4",
			ReleaseNumber = "n",
			RequestReferenceNumber = "P",
			ContractNumber = "d",
			ReferenceNumber = "s",
			AcknowledgmentDate = "q2fDvY",
		};

		var actual = Map.MapObject<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rB", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.AcknowledgmentType = "sJ";
		subject.PurchaseOrderNumber = "l";
		subject.PurchaseOrderDate = "VzqTz4";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sJ", true)]
	public void Validation_RequiredAcknowledgmentType(string acknowledgmentType, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "rB";
		subject.PurchaseOrderNumber = "l";
		subject.PurchaseOrderDate = "VzqTz4";
		subject.AcknowledgmentType = acknowledgmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "rB";
		subject.AcknowledgmentType = "sJ";
		subject.PurchaseOrderDate = "VzqTz4";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VzqTz4", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "rB";
		subject.AcknowledgmentType = "sJ";
		subject.PurchaseOrderNumber = "l";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
