using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCA*G2*BS*e*3*Z*FgcjEE0j*z*4*2*I0PKhSxU*2wpFWUfK*8wXHpLBF*KL*TK*Ye";

		var expected = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment()
		{
			TransactionSetPurposeCode = "G2",
			AcknowledgmentType = "BS",
			PurchaseOrderNumber = "e",
			ReleaseNumber = "3",
			ChangeOrderSequenceNumber = "Z",
			Date = "FgcjEE0j",
			RequestReferenceNumber = "z",
			ContractNumber = "4",
			ReferenceIdentification = "2",
			Date2 = "I0PKhSxU",
			Date3 = "2wpFWUfK",
			Date4 = "8wXHpLBF",
			PurchaseOrderTypeCode = "KL",
			SecurityLevelCode = "TK",
			TransactionTypeCode = "Ye",
		};

		var actual = Map.MapObject<BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G2", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.PurchaseOrderNumber = "e";
		subject.Date = "FgcjEE0j";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "G2";
		subject.Date = "FgcjEE0j";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FgcjEE0j", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "G2";
		subject.PurchaseOrderNumber = "e";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
