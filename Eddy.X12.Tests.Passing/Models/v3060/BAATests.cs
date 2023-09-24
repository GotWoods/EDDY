using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAA*G9*7m*nzthTt*DT*v*5TNm";

		var expected = new BAA_BeginningSegmentForProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "G9",
			TransactionTypeCode = "7m",
			Date = "nzthTt",
			ReferenceIdentificationQualifier = "DT",
			ReferenceIdentification = "v",
			Time = "5TNm",
		};

		var actual = Map.MapObject<BAA_BeginningSegmentForProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G9", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionTypeCode = "7m";
		subject.Date = "nzthTt";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "DT";
			subject.ReferenceIdentification = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7m", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "G9";
		subject.Date = "nzthTt";
		subject.TransactionTypeCode = transactionTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "DT";
			subject.ReferenceIdentification = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nzthTt", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "G9";
		subject.TransactionTypeCode = "7m";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "DT";
			subject.ReferenceIdentification = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DT", "v", true)]
	[InlineData("DT", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "G9";
		subject.TransactionTypeCode = "7m";
		subject.Date = "nzthTt";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
