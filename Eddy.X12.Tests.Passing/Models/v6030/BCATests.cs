using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCA*bj*68*v*t*H*BzHPzQJa*g*4*W*B4X0WbAv*A47qZePy*u51Rv3d1*OU*kL*bN";

		var expected = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment()
		{
			TransactionSetPurposeCode = "bj",
			AcknowledgmentTypeCode = "68",
			PurchaseOrderNumber = "v",
			ReleaseNumber = "t",
			ChangeOrderSequenceNumber = "H",
			Date = "BzHPzQJa",
			RequestReferenceNumber = "g",
			ContractNumber = "4",
			ReferenceIdentification = "W",
			Date2 = "B4X0WbAv",
			Date3 = "A47qZePy",
			Date4 = "u51Rv3d1",
			PurchaseOrderTypeCode = "OU",
			SecurityLevelCode = "kL",
			TransactionTypeCode = "bN",
		};

		var actual = Map.MapObject<BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bj", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.PurchaseOrderNumber = "v";
		subject.Date = "BzHPzQJa";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "bj";
		subject.Date = "BzHPzQJa";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BzHPzQJa", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "bj";
		subject.PurchaseOrderNumber = "v";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
