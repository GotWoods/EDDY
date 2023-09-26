using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSC*ov*P*3S*F*KU*k*j*1";

		var expected = new SSC_BeginningSegmentForServiceCommitmentAdvice()
		{
			TransactionSetPurposeCode = "ov",
			ReferenceNumber = "P",
			DateTimePeriodFormatQualifier = "3S",
			DateTimePeriod = "F",
			IdentificationCode = "KU",
			ServiceCommitmentTypeCode = "k",
			LoadEmptyStatusCode = "j",
			Percent = 1,
		};

		var actual = Map.MapObject<SSC_BeginningSegmentForServiceCommitmentAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ov", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.ReferenceNumber = "P";
		subject.DateTimePeriodFormatQualifier = "3S";
		subject.DateTimePeriod = "F";
		subject.IdentificationCode = "KU";
		subject.ServiceCommitmentTypeCode = "k";
		subject.LoadEmptyStatusCode = "j";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ov";
		subject.DateTimePeriodFormatQualifier = "3S";
		subject.DateTimePeriod = "F";
		subject.IdentificationCode = "KU";
		subject.ServiceCommitmentTypeCode = "k";
		subject.LoadEmptyStatusCode = "j";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3S", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ov";
		subject.ReferenceNumber = "P";
		subject.DateTimePeriod = "F";
		subject.IdentificationCode = "KU";
		subject.ServiceCommitmentTypeCode = "k";
		subject.LoadEmptyStatusCode = "j";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ov";
		subject.ReferenceNumber = "P";
		subject.DateTimePeriodFormatQualifier = "3S";
		subject.IdentificationCode = "KU";
		subject.ServiceCommitmentTypeCode = "k";
		subject.LoadEmptyStatusCode = "j";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KU", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ov";
		subject.ReferenceNumber = "P";
		subject.DateTimePeriodFormatQualifier = "3S";
		subject.DateTimePeriod = "F";
		subject.ServiceCommitmentTypeCode = "k";
		subject.LoadEmptyStatusCode = "j";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredServiceCommitmentTypeCode(string serviceCommitmentTypeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ov";
		subject.ReferenceNumber = "P";
		subject.DateTimePeriodFormatQualifier = "3S";
		subject.DateTimePeriod = "F";
		subject.IdentificationCode = "KU";
		subject.LoadEmptyStatusCode = "j";
		//Test Parameters
		subject.ServiceCommitmentTypeCode = serviceCommitmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ov";
		subject.ReferenceNumber = "P";
		subject.DateTimePeriodFormatQualifier = "3S";
		subject.DateTimePeriod = "F";
		subject.IdentificationCode = "KU";
		subject.ServiceCommitmentTypeCode = "k";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
