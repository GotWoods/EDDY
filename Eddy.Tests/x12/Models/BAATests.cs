using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAA*iD*Uq*QAFR8TO0*kL*E*Gicx";

		var expected = new BAA_BeginningSegmentForProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "iD",
			TransactionTypeCode = "Uq",
			Date = "QAFR8TO0",
			ReferenceIdentificationQualifier = "kL",
			ReferenceIdentification = "E",
			Time = "Gicx",
		};

		var actual = Map.MapObject<BAA_BeginningSegmentForProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iD", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionTypeCode = "Uq";
		subject.Date = "QAFR8TO0";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uq", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "iD";
		subject.Date = "QAFR8TO0";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QAFR8TO0", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "iD";
		subject.TransactionTypeCode = "Uq";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("kL", "E", true)]
	[InlineData("", "E", false)]
	[InlineData("kL", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "iD";
		subject.TransactionTypeCode = "Uq";
		subject.Date = "QAFR8TO0";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
