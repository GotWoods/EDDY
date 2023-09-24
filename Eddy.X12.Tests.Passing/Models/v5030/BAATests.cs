using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAA*dx*uG*Jil9UaMw*Hw*B*KnjQ";

		var expected = new BAA_BeginningSegmentForProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "dx",
			TransactionTypeCode = "uG",
			Date = "Jil9UaMw",
			ReferenceIdentificationQualifier = "Hw",
			ReferenceIdentification = "B",
			Time = "KnjQ",
		};

		var actual = Map.MapObject<BAA_BeginningSegmentForProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dx", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionTypeCode = "uG";
		subject.Date = "Jil9UaMw";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Hw";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uG", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "dx";
		subject.Date = "Jil9UaMw";
		subject.TransactionTypeCode = transactionTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Hw";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jil9UaMw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "dx";
		subject.TransactionTypeCode = "uG";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Hw";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hw", "B", true)]
	[InlineData("Hw", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "dx";
		subject.TransactionTypeCode = "uG";
		subject.Date = "Jil9UaMw";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
