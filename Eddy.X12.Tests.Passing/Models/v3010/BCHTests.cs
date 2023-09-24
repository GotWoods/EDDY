using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCH*a7*Km*e*t*R*9CYreg*r*t*Z*wNyw27*HeRKle";

		var expected = new BCH_BeginningSegmentForPurchaseOrderChange()
		{
			TransactionSetPurposeCode = "a7",
			PurchaseOrderTypeCode = "Km",
			PurchaseOrderNumber = "e",
			ReleaseNumber = "t",
			ChangeOrderSequenceNumber = "R",
			PurchaseOrderDate = "9CYreg",
			RequestReferenceNumber = "r",
			ContractNumber = "t",
			ReferenceNumber = "Z",
			AcknowledgmentDate = "wNyw27",
			PurchaseOrderChangeRequestDate = "HeRKle",
		};

		var actual = Map.MapObject<BCH_BeginningSegmentForPurchaseOrderChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a7", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.PurchaseOrderTypeCode = "Km";
		subject.PurchaseOrderNumber = "e";
		subject.PurchaseOrderDate = "9CYreg";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Km", true)]
	public void Validation_RequiredPurchaseOrderTypeCode(string purchaseOrderTypeCode, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "a7";
		subject.PurchaseOrderNumber = "e";
		subject.PurchaseOrderDate = "9CYreg";
		subject.PurchaseOrderTypeCode = purchaseOrderTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "a7";
		subject.PurchaseOrderTypeCode = "Km";
		subject.PurchaseOrderDate = "9CYreg";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9CYreg", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new BCH_BeginningSegmentForPurchaseOrderChange();
		subject.TransactionSetPurposeCode = "a7";
		subject.PurchaseOrderTypeCode = "Km";
		subject.PurchaseOrderNumber = "e";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
