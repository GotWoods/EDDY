using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCD*jNuEwp9w*6*e*I*B*f0xXcRhA*o*Q*Bo7t0jyb*M*Nz*3M*cJ*E*p";

		var expected = new BCD_BeginningCreditDebitAdjustment()
		{
			Date = "jNuEwp9w",
			CreditDebitAdjustmentNumber = "6",
			TransactionHandlingCode = "e",
			Amount = "I",
			CreditDebitFlagCode = "B",
			Date2 = "f0xXcRhA",
			InvoiceNumber = "o",
			VendorOrderNumber = "Q",
			Date3 = "Bo7t0jyb",
			PurchaseOrderNumber = "M",
			TransactionSetPurposeCode = "Nz",
			TransactionTypeCode = "3M",
			ReferenceIdentificationQualifier = "cJ",
			ReferenceIdentification = "E",
			ActionCode = "p",
		};

		var actual = Map.MapObject<BCD_BeginningCreditDebitAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jNuEwp9w", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.CreditDebitAdjustmentNumber = "6";
		subject.TransactionHandlingCode = "e";
		subject.Amount = "I";
		subject.CreditDebitFlagCode = "B";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "cJ";
			subject.ReferenceIdentification = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "jNuEwp9w";
		subject.TransactionHandlingCode = "e";
		subject.Amount = "I";
		subject.CreditDebitFlagCode = "B";
		//Test Parameters
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "cJ";
			subject.ReferenceIdentification = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "jNuEwp9w";
		subject.CreditDebitAdjustmentNumber = "6";
		subject.Amount = "I";
		subject.CreditDebitFlagCode = "B";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "cJ";
			subject.ReferenceIdentification = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "jNuEwp9w";
		subject.CreditDebitAdjustmentNumber = "6";
		subject.TransactionHandlingCode = "e";
		subject.CreditDebitFlagCode = "B";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "cJ";
			subject.ReferenceIdentification = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "jNuEwp9w";
		subject.CreditDebitAdjustmentNumber = "6";
		subject.TransactionHandlingCode = "e";
		subject.Amount = "I";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "cJ";
			subject.ReferenceIdentification = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cJ", "E", true)]
	[InlineData("cJ", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCD_BeginningCreditDebitAdjustment();
		//Required fields
		subject.Date = "jNuEwp9w";
		subject.CreditDebitAdjustmentNumber = "6";
		subject.TransactionHandlingCode = "e";
		subject.Amount = "I";
		subject.CreditDebitFlagCode = "B";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
