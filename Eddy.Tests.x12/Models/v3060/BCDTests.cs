using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCD*7dL6MA*g*H*S*d*EJTTmy*4*0*5o89La*3*zl*3e*Vc*B*7";

		var expected = new BCD_BeginningCreditDebitAdjustment()
		{
			Date = "7dL6MA",
			CreditDebitAdjustmentNumber = "g",
			TransactionHandlingCode = "H",
			Amount = "S",
			CreditDebitFlagCode = "d",
			Date2 = "EJTTmy",
			InvoiceNumber = "4",
			VendorOrderNumber = "0",
			Date3 = "5o89La",
			PurchaseOrderNumber = "3",
			TransactionSetPurposeCode = "zl",
			TransactionTypeCode = "3e",
			ReferenceIdentificationQualifier = "Vc",
			ReferenceIdentification = "B",
			ActionCode = "7",
		};

		var actual = Map.MapObject<BCD_BeginningCreditDebitAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7dL6MA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.CreditDebitAdjustmentNumber = "g";
		subject.TransactionHandlingCode = "H";
		subject.Amount = "S";
		subject.CreditDebitFlagCode = "d";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Vc";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "7dL6MA";
		subject.TransactionHandlingCode = "H";
		subject.Amount = "S";
		subject.CreditDebitFlagCode = "d";
		//Test Parameters
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Vc";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "7dL6MA";
		subject.CreditDebitAdjustmentNumber = "g";
		subject.Amount = "S";
		subject.CreditDebitFlagCode = "d";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Vc";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "7dL6MA";
		subject.CreditDebitAdjustmentNumber = "g";
		subject.TransactionHandlingCode = "H";
		subject.CreditDebitFlagCode = "d";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Vc";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "7dL6MA";
		subject.CreditDebitAdjustmentNumber = "g";
		subject.TransactionHandlingCode = "H";
		subject.Amount = "S";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Vc";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vc", "B", true)]
	[InlineData("Vc", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "7dL6MA";
		subject.CreditDebitAdjustmentNumber = "g";
		subject.TransactionHandlingCode = "H";
		subject.Amount = "S";
		subject.CreditDebitFlagCode = "d";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
