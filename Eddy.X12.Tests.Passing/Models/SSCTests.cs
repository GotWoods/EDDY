using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSC*lW*l*en*H*Nt*9*m*9";

		var expected = new SSC_BeginningSegmentForServiceCommitmentAdvice()
		{
			TransactionSetPurposeCode = "lW",
			ReferenceIdentification = "l",
			DateTimePeriodFormatQualifier = "en",
			DateTimePeriod = "H",
			IdentificationCode = "Nt",
			ServiceCommitmentTypeCode = "9",
			LoadEmptyStatusCode = "m",
			PercentIntegerFormat = 9,
		};

		var actual = Map.MapObject<SSC_BeginningSegmentForServiceCommitmentAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lW", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "en";
		subject.DateTimePeriod = "H";
		subject.IdentificationCode = "Nt";
		subject.ServiceCommitmentTypeCode = "9";
		subject.LoadEmptyStatusCode = "m";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		subject.TransactionSetPurposeCode = "lW";
		subject.DateTimePeriodFormatQualifier = "en";
		subject.DateTimePeriod = "H";
		subject.IdentificationCode = "Nt";
		subject.ServiceCommitmentTypeCode = "9";
		subject.LoadEmptyStatusCode = "m";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("en", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		subject.TransactionSetPurposeCode = "lW";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriod = "H";
		subject.IdentificationCode = "Nt";
		subject.ServiceCommitmentTypeCode = "9";
		subject.LoadEmptyStatusCode = "m";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		subject.TransactionSetPurposeCode = "lW";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "en";
		subject.IdentificationCode = "Nt";
		subject.ServiceCommitmentTypeCode = "9";
		subject.LoadEmptyStatusCode = "m";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nt", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		subject.TransactionSetPurposeCode = "lW";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "en";
		subject.DateTimePeriod = "H";
		subject.ServiceCommitmentTypeCode = "9";
		subject.LoadEmptyStatusCode = "m";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredServiceCommitmentTypeCode(string serviceCommitmentTypeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		subject.TransactionSetPurposeCode = "lW";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "en";
		subject.DateTimePeriod = "H";
		subject.IdentificationCode = "Nt";
		subject.LoadEmptyStatusCode = "m";
		subject.ServiceCommitmentTypeCode = serviceCommitmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		subject.TransactionSetPurposeCode = "lW";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "en";
		subject.DateTimePeriod = "H";
		subject.IdentificationCode = "Nt";
		subject.ServiceCommitmentTypeCode = "9";
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
