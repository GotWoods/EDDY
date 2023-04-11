using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCD*AxuQNLuO*3*5*b*q*BjlZ27We*z*2*ehv0Tl7j*7*UH*ft*GU*p*k";

		var expected = new BCD_BeginningCreditDebitAdjustment()
		{
			Date = "AxuQNLuO",
			CreditDebitAdjustmentNumber = "3",
			TransactionHandlingCode = "5",
			Amount = "b",
			CreditDebitFlagCode = "q",
			Date2 = "BjlZ27We",
			InvoiceNumber = "z",
			VendorOrderNumber = "2",
			Date3 = "ehv0Tl7j",
			PurchaseOrderNumber = "7",
			TransactionSetPurposeCode = "UH",
			TransactionTypeCode = "ft",
			ReferenceIdentificationQualifier = "GU",
			ReferenceIdentification = "p",
			ActionCode = "k",
		};

		var actual = Map.MapObject<BCD_BeginningCreditDebitAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AxuQNLuO", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		subject.CreditDebitAdjustmentNumber = "3";
		subject.TransactionHandlingCode = "5";
		subject.Amount = "b";
		subject.CreditDebitFlagCode = "q";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validatation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		subject.Date = "AxuQNLuO";
		subject.TransactionHandlingCode = "5";
		subject.Amount = "b";
		subject.CreditDebitFlagCode = "q";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validatation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		subject.Date = "AxuQNLuO";
		subject.CreditDebitAdjustmentNumber = "3";
		subject.Amount = "b";
		subject.CreditDebitFlagCode = "q";
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validatation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		subject.Date = "AxuQNLuO";
		subject.CreditDebitAdjustmentNumber = "3";
		subject.TransactionHandlingCode = "5";
		subject.CreditDebitFlagCode = "q";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validatation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		subject.Date = "AxuQNLuO";
		subject.CreditDebitAdjustmentNumber = "3";
		subject.TransactionHandlingCode = "5";
		subject.Amount = "b";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("GU", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("GU", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		subject.Date = "AxuQNLuO";
		subject.CreditDebitAdjustmentNumber = "3";
		subject.TransactionHandlingCode = "5";
		subject.Amount = "b";
		subject.CreditDebitFlagCode = "q";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
