using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSC*VA*N*xv*l*W1*C*i*1";

		var expected = new SSC_BeginningSegmentForServiceCommitmentAdvice()
		{
			TransactionSetPurposeCode = "VA",
			ReferenceIdentification = "N",
			DateTimePeriodFormatQualifier = "xv",
			DateTimePeriod = "l",
			IdentificationCode = "W1",
			ServiceCommitmentTypeCode = "C",
			LoadEmptyStatusCode = "i",
			PercentIntegerFormat = 1,
		};

		var actual = Map.MapObject<SSC_BeginningSegmentForServiceCommitmentAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VA", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.ReferenceIdentification = "N";
		subject.DateTimePeriodFormatQualifier = "xv";
		subject.DateTimePeriod = "l";
		subject.IdentificationCode = "W1";
		subject.ServiceCommitmentTypeCode = "C";
		subject.LoadEmptyStatusCode = "i";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "VA";
		subject.DateTimePeriodFormatQualifier = "xv";
		subject.DateTimePeriod = "l";
		subject.IdentificationCode = "W1";
		subject.ServiceCommitmentTypeCode = "C";
		subject.LoadEmptyStatusCode = "i";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xv", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "VA";
		subject.ReferenceIdentification = "N";
		subject.DateTimePeriod = "l";
		subject.IdentificationCode = "W1";
		subject.ServiceCommitmentTypeCode = "C";
		subject.LoadEmptyStatusCode = "i";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "VA";
		subject.ReferenceIdentification = "N";
		subject.DateTimePeriodFormatQualifier = "xv";
		subject.IdentificationCode = "W1";
		subject.ServiceCommitmentTypeCode = "C";
		subject.LoadEmptyStatusCode = "i";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W1", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "VA";
		subject.ReferenceIdentification = "N";
		subject.DateTimePeriodFormatQualifier = "xv";
		subject.DateTimePeriod = "l";
		subject.ServiceCommitmentTypeCode = "C";
		subject.LoadEmptyStatusCode = "i";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredServiceCommitmentTypeCode(string serviceCommitmentTypeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "VA";
		subject.ReferenceIdentification = "N";
		subject.DateTimePeriodFormatQualifier = "xv";
		subject.DateTimePeriod = "l";
		subject.IdentificationCode = "W1";
		subject.LoadEmptyStatusCode = "i";
		//Test Parameters
		subject.ServiceCommitmentTypeCode = serviceCommitmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "VA";
		subject.ReferenceIdentification = "N";
		subject.DateTimePeriodFormatQualifier = "xv";
		subject.DateTimePeriod = "l";
		subject.IdentificationCode = "W1";
		subject.ServiceCommitmentTypeCode = "C";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
