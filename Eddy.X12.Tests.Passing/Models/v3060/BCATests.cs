using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCA*zB*jF*N*L*g*5x9p2C*3*B*h*ZxmclI*RJRhZ5*FTyoOF*eU*zy*6O";

		var expected = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment()
		{
			TransactionSetPurposeCode = "zB",
			AcknowledgmentType = "jF",
			PurchaseOrderNumber = "N",
			ReleaseNumber = "L",
			ChangeOrderSequenceNumber = "g",
			Date = "5x9p2C",
			RequestReferenceNumber = "3",
			ContractNumber = "B",
			ReferenceIdentification = "h",
			Date2 = "ZxmclI",
			Date3 = "RJRhZ5",
			Date4 = "FTyoOF",
			PurchaseOrderTypeCode = "eU",
			SecurityLevelCode = "zy",
			TransactionTypeCode = "6O",
		};

		var actual = Map.MapObject<BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zB", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.PurchaseOrderNumber = "N";
		subject.Date = "5x9p2C";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "zB";
		subject.Date = "5x9p2C";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5x9p2C", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment();
		subject.TransactionSetPurposeCode = "zB";
		subject.PurchaseOrderNumber = "N";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
