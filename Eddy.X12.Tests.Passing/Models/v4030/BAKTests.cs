using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BAKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAK*ii*iG*R*WUVvIR0h*p*G*f*o*hwtpFbaq*FY";

		var expected = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment()
		{
			TransactionSetPurposeCode = "ii",
			AcknowledgmentType = "iG",
			PurchaseOrderNumber = "R",
			Date = "WUVvIR0h",
			ReleaseNumber = "p",
			RequestReferenceNumber = "G",
			ContractNumber = "f",
			ReferenceIdentification = "o",
			Date2 = "hwtpFbaq",
			TransactionTypeCode = "FY",
		};

		var actual = Map.MapObject<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ii", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.AcknowledgmentType = "iG";
		subject.PurchaseOrderNumber = "R";
		subject.Date = "WUVvIR0h";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iG", true)]
	public void Validation_RequiredAcknowledgmentType(string acknowledgmentType, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "ii";
		subject.PurchaseOrderNumber = "R";
		subject.Date = "WUVvIR0h";
		subject.AcknowledgmentType = acknowledgmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "ii";
		subject.AcknowledgmentType = "iG";
		subject.Date = "WUVvIR0h";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WUVvIR0h", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAK_BeginningSegmentForPurchaseOrderAcknowledgment();
		subject.TransactionSetPurposeCode = "ii";
		subject.AcknowledgmentType = "iG";
		subject.PurchaseOrderNumber = "R";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
