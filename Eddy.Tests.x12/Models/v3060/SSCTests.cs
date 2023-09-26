using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSC*HD*l*v6*z*ia*2*6*6";

		var expected = new SSC_BeginningSegmentForServiceCommitmentAdvice()
		{
			TransactionSetPurposeCode = "HD",
			ReferenceIdentification = "l",
			DateTimePeriodFormatQualifier = "v6",
			DateTimePeriod = "z",
			IdentificationCode = "ia",
			ServiceCommitmentTypeCode = "2",
			LoadEmptyStatusCode = "6",
			Percent = 6,
		};

		var actual = Map.MapObject<SSC_BeginningSegmentForServiceCommitmentAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HD", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "v6";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "ia";
		subject.ServiceCommitmentTypeCode = "2";
		subject.LoadEmptyStatusCode = "6";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "HD";
		subject.DateTimePeriodFormatQualifier = "v6";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "ia";
		subject.ServiceCommitmentTypeCode = "2";
		subject.LoadEmptyStatusCode = "6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v6", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "HD";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "ia";
		subject.ServiceCommitmentTypeCode = "2";
		subject.LoadEmptyStatusCode = "6";
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
		subject.TransactionSetPurposeCode = "HD";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "v6";
		subject.IdentificationCode = "ia";
		subject.ServiceCommitmentTypeCode = "2";
		subject.LoadEmptyStatusCode = "6";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ia", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "HD";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "v6";
		subject.DateTimePeriod = "z";
		subject.ServiceCommitmentTypeCode = "2";
		subject.LoadEmptyStatusCode = "6";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredServiceCommitmentTypeCode(string serviceCommitmentTypeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "HD";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "v6";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "ia";
		subject.LoadEmptyStatusCode = "6";
		//Test Parameters
		subject.ServiceCommitmentTypeCode = serviceCommitmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "HD";
		subject.ReferenceIdentification = "l";
		subject.DateTimePeriodFormatQualifier = "v6";
		subject.DateTimePeriod = "z";
		subject.IdentificationCode = "ia";
		subject.ServiceCommitmentTypeCode = "2";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
