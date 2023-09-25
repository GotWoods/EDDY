using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCD*OVUCmn*W*W*7*i*8UOuIU*4*N*PzxG7S*Q*Zw*X2*H9*t";

		var expected = new BCD_BeginningCreditDebitAdjustment()
		{
			Date = "OVUCmn",
			CreditDebitAdjustmentNumber = "W",
			TransactionHandlingCode = "W",
			Amount = "7",
			CreditDebitFlagCode = "i",
			Date2 = "8UOuIU",
			InvoiceNumber = "4",
			VendorOrderNumber = "N",
			Date3 = "PzxG7S",
			PurchaseOrderNumber = "Q",
			TransactionSetPurposeCode = "Zw",
			TransactionTypeCode = "X2",
			ReferenceNumberQualifier = "H9",
			ReferenceNumber = "t",
		};

		var actual = Map.MapObject<BCD_BeginningCreditDebitAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OVUCmn", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "W";
		subject.Amount = "7";
		subject.CreditDebitFlagCode = "i";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "H9";
			subject.ReferenceNumber = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "OVUCmn";
		subject.TransactionHandlingCode = "W";
		subject.Amount = "7";
		subject.CreditDebitFlagCode = "i";
		//Test Parameters
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "H9";
			subject.ReferenceNumber = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "OVUCmn";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.Amount = "7";
		subject.CreditDebitFlagCode = "i";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "H9";
			subject.ReferenceNumber = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "OVUCmn";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "W";
		subject.CreditDebitFlagCode = "i";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "H9";
			subject.ReferenceNumber = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "OVUCmn";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "W";
		subject.Amount = "7";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "H9";
			subject.ReferenceNumber = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H9", "t", true)]
	[InlineData("H9", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "OVUCmn";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "W";
		subject.Amount = "7";
		subject.CreditDebitFlagCode = "i";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
