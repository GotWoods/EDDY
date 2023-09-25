using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCD*f5WXKZ*W*j*c*v*k6Y2Na*T*V*zW39q9*r*ej*Ma*sA*Z*k";

		var expected = new BCD_BeginningCreditDebitAdjustment()
		{
			Date = "f5WXKZ",
			CreditDebitAdjustmentNumber = "W",
			TransactionHandlingCode = "j",
			Amount = "c",
			CreditDebitFlagCode = "v",
			Date2 = "k6Y2Na",
			InvoiceNumber = "T",
			VendorOrderNumber = "V",
			Date3 = "zW39q9",
			PurchaseOrderNumber = "r",
			TransactionSetPurposeCode = "ej",
			TransactionTypeCode = "Ma",
			ReferenceNumberQualifier = "sA",
			ReferenceNumber = "Z",
			ActionCode = "k",
		};

		var actual = Map.MapObject<BCD_BeginningCreditDebitAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f5WXKZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "j";
		subject.Amount = "c";
		subject.CreditDebitFlagCode = "v";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "sA";
			subject.ReferenceNumber = "Z";
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
		subject.Date = "f5WXKZ";
		subject.TransactionHandlingCode = "j";
		subject.Amount = "c";
		subject.CreditDebitFlagCode = "v";
		//Test Parameters
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "sA";
			subject.ReferenceNumber = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "f5WXKZ";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.Amount = "c";
		subject.CreditDebitFlagCode = "v";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "sA";
			subject.ReferenceNumber = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "f5WXKZ";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "j";
		subject.CreditDebitFlagCode = "v";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "sA";
			subject.ReferenceNumber = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "f5WXKZ";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "j";
		subject.Amount = "c";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "sA";
			subject.ReferenceNumber = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sA", "Z", true)]
	[InlineData("sA", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "f5WXKZ";
		subject.CreditDebitAdjustmentNumber = "W";
		subject.TransactionHandlingCode = "j";
		subject.Amount = "c";
		subject.CreditDebitFlagCode = "v";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
