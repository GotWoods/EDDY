using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070.Composites;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*kR*UZ*7*P*q**x*s*9***SY*C5*NX*cv*G5";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "kR",
			PurchaseOrderTypeCode = "UZ",
			PurchaseOrderNumber = "7",
			ReleaseNumber = "P",
			ChangeOrderSequenceNumber = "q",
			CompositeDate = null,
			RequestReferenceNumber = "x",
			ContractNumber = "s",
			ReferenceIdentification = "9",
			CompositeDate2 = null,
			CompositeDate3 = null,
			ContractTypeCode = "SY",
			SecurityLevelCode = "C5",
			AcknowledgmentType = "NX",
			TransactionTypeCode = "cv",
			PurchaseCategory = "G5",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kR", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "UZ";
		subject.PurchaseOrderNumber = "7";
		subject.CompositeDate = new C041_CompositeDate();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UZ", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "kR";
		subject.PurchaseOrderNumber = "7";
		subject.CompositeDate = new C041_CompositeDate();
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "kR";
		subject.PurchaseOrderTypeCode = "UZ";
		subject.CompositeDate = new C041_CompositeDate();
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}
}
