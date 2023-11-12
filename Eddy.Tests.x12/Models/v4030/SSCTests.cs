using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSC*8v*u*TP*z*Dl*s*h*2";

		var expected = new SSC_BeginningSegmentForServiceCommitmentAdvice()
		{
			TransactionSetPurposeCode = "8v",
			ReferenceIdentification = "u",
			DateTimePeriodFormatQualifier = "TP",
			DateTimePeriod = "z",
			IdentificationCode = "Dl",
			ServiceCommitmentTypeCode = "s",
			LoadEmptyStatusCode = "h",
			Percent = 2,
		};

		var actual = Map.MapObject<SSC_BeginningSegmentForServiceCommitmentAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8v", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.ReferenceIdentification = "u";
		subject.DateTimePeriodFormatQualifier = "TP";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "Dl";
		subject.ServiceCommitmentTypeCode = "s";
		subject.LoadEmptyStatusCode = "h";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "8v";
		subject.DateTimePeriodFormatQualifier = "TP";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "Dl";
		subject.ServiceCommitmentTypeCode = "s";
		subject.LoadEmptyStatusCode = "h";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TP", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "8v";
		subject.ReferenceIdentification = "u";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "Dl";
		subject.ServiceCommitmentTypeCode = "s";
		subject.LoadEmptyStatusCode = "h";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "8v";
		subject.ReferenceIdentification = "u";
		subject.DateTimePeriodFormatQualifier = "TP";
		subject.IdentificationCode = "Dl";
		subject.ServiceCommitmentTypeCode = "s";
		subject.LoadEmptyStatusCode = "h";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dl", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "8v";
		subject.ReferenceIdentification = "u";
		subject.DateTimePeriodFormatQualifier = "TP";
		subject.DateTimePeriod = "z";
		subject.ServiceCommitmentTypeCode = "s";
		subject.LoadEmptyStatusCode = "h";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredServiceCommitmentTypeCode(string serviceCommitmentTypeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "8v";
		subject.ReferenceIdentification = "u";
		subject.DateTimePeriodFormatQualifier = "TP";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "Dl";
		subject.LoadEmptyStatusCode = "h";
		//Test Parameters
		subject.ServiceCommitmentTypeCode = serviceCommitmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "8v";
		subject.ReferenceIdentification = "u";
		subject.DateTimePeriodFormatQualifier = "TP";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "Dl";
		subject.ServiceCommitmentTypeCode = "s";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
