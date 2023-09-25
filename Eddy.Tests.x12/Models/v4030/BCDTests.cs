using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCD*uKrUKUtM*B*E*l*V*MOLssPKY*A*Q*X5To3MGe*8*Xu*Qk*Lh*c*S";

		var expected = new BCD_BeginningCreditDebitAdjustment()
		{
			Date = "uKrUKUtM",
			CreditDebitAdjustmentNumber = "B",
			TransactionHandlingCode = "E",
			Amount = "l",
			CreditDebitFlagCode = "V",
			Date2 = "MOLssPKY",
			InvoiceNumber = "A",
			VendorOrderNumber = "Q",
			Date3 = "X5To3MGe",
			PurchaseOrderNumber = "8",
			TransactionSetPurposeCode = "Xu",
			TransactionTypeCode = "Qk",
			ReferenceIdentificationQualifier = "Lh",
			ReferenceIdentification = "c",
			ActionCode = "S",
		};

		var actual = Map.MapObject<BCD_BeginningCreditDebitAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uKrUKUtM", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.CreditDebitAdjustmentNumber = "B";
		subject.TransactionHandlingCode = "E";
		subject.Amount = "l";
		subject.CreditDebitFlagCode = "V";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Lh";
			subject.ReferenceIdentification = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "uKrUKUtM";
		subject.TransactionHandlingCode = "E";
		subject.Amount = "l";
		subject.CreditDebitFlagCode = "V";
		//Test Parameters
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Lh";
			subject.ReferenceIdentification = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "uKrUKUtM";
		subject.CreditDebitAdjustmentNumber = "B";
		subject.Amount = "l";
		subject.CreditDebitFlagCode = "V";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Lh";
			subject.ReferenceIdentification = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "uKrUKUtM";
		subject.CreditDebitAdjustmentNumber = "B";
		subject.TransactionHandlingCode = "E";
		subject.CreditDebitFlagCode = "V";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Lh";
			subject.ReferenceIdentification = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "uKrUKUtM";
		subject.CreditDebitAdjustmentNumber = "B";
		subject.TransactionHandlingCode = "E";
		subject.Amount = "l";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Lh";
			subject.ReferenceIdentification = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lh", "c", true)]
	[InlineData("Lh", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "uKrUKUtM";
		subject.CreditDebitAdjustmentNumber = "B";
		subject.TransactionHandlingCode = "E";
		subject.Amount = "l";
		subject.CreditDebitFlagCode = "V";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
