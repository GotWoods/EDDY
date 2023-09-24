using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCA*Lx*au*3*D*K*soQYymW1*X*B*g*zPHq8Ker*QDY3FgFD*lQKHCT4N*Sm*WZ*Hi";

		var expected = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment()
		{
			TransactionSetPurposeCode = "Lx",
			AcknowledgmentTypeCode = "au",
			PurchaseOrderNumber = "3",
			ReleaseNumber = "D",
			ChangeOrderSequenceNumber = "K",
			Date = "soQYymW1",
			RequestReferenceNumber = "X",
			ContractNumber = "B",
			ReferenceIdentification = "g",
			Date2 = "zPHq8Ker",
			Date3 = "QDY3FgFD",
			Date4 = "lQKHCT4N",
			PurchaseOrderTypeCode = "Sm",
			SecurityLevelCode = "WZ",
			TransactionTypeCode = "Hi",
		};

		var actual = Map.MapObject<BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lx", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.PurchaseOrderNumber = "3";
		subject.Date = "soQYymW1";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "Lx";
		subject.Date = "soQYymW1";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("soQYymW1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "Lx";
		subject.PurchaseOrderNumber = "3";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
