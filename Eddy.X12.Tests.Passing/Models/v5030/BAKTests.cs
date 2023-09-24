using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BAKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAK*Qf*9P*j*Qs0mnRLX*X*7*R*m*toBiFXKg*2j";

		var expected = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment()
		{
			TransactionSetPurposeCode = "Qf",
			AcknowledgmentType = "9P",
			PurchaseOrderNumber = "j",
			Date = "Qs0mnRLX",
			ReleaseNumber = "X",
			RequestReferenceNumber = "7",
			ContractNumber = "R",
			ReferenceIdentification = "m",
			Date2 = "toBiFXKg",
			TransactionTypeCode = "2j",
		};

		var actual = Map.MapObject<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qf", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.AcknowledgmentType = "9P";
		subject.PurchaseOrderNumber = "j";
		subject.Date = "Qs0mnRLX";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9P", true)]
	public void Validation_RequiredAcknowledgmentType(string acknowledgmentType, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "Qf";
		subject.PurchaseOrderNumber = "j";
		subject.Date = "Qs0mnRLX";
		subject.AcknowledgmentType = acknowledgmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "Qf";
		subject.AcknowledgmentType = "9P";
		subject.Date = "Qs0mnRLX";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qs0mnRLX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "Qf";
		subject.AcknowledgmentType = "9P";
		subject.PurchaseOrderNumber = "j";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
