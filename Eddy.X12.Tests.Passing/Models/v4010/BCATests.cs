using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCA*2i*9D*v*1*7*1muKhs5Z*a*S*1*ifFTUklE*eXwSdQSw*dn2I1z3d*6b*go*1m";

		var expected = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment()
		{
			TransactionSetPurposeCode = "2i",
			AcknowledgmentType = "9D",
			PurchaseOrderNumber = "v",
			ReleaseNumber = "1",
			ChangeOrderSequenceNumber = "7",
			Date = "1muKhs5Z",
			RequestReferenceNumber = "a",
			ContractNumber = "S",
			ReferenceIdentification = "1",
			Date2 = "ifFTUklE",
			Date3 = "eXwSdQSw",
			Date4 = "dn2I1z3d",
			PurchaseOrderTypeCode = "6b",
			SecurityLevelCode = "go",
			TransactionTypeCode = "1m",
		};

		var actual = Map.MapObject<BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2i", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.PurchaseOrderNumber = "v";
		subject.Date = "1muKhs5Z";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "2i";
		subject.Date = "1muKhs5Z";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1muKhs5Z", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "2i";
		subject.PurchaseOrderNumber = "v";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
