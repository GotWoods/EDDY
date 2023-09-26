using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSC*wZ*Y*wi*k*V5*E*U*5";

		var expected = new SSC_BeginningSegmentForServiceCommitmentAdvice()
		{
			TransactionSetPurposeCode = "wZ",
			ReferenceIdentification = "Y",
			DateTimePeriodFormatQualifier = "wi",
			DateTimePeriod = "k",
			IdentificationCode = "V5",
			ServiceCommitmentTypeCode = "E",
			LoadEmptyStatusCode = "U",
			PercentIntegerFormat = 5,
		};

		var actual = Map.MapObject<SSC_BeginningSegmentForServiceCommitmentAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wZ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.ReferenceIdentification = "Y";
		subject.DateTimePeriodFormatQualifier = "wi";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "V5";
		subject.ServiceCommitmentTypeCode = "E";
		subject.LoadEmptyStatusCode = "U";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "wZ";
		subject.DateTimePeriodFormatQualifier = "wi";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "V5";
		subject.ServiceCommitmentTypeCode = "E";
		subject.LoadEmptyStatusCode = "U";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wi", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "wZ";
		subject.ReferenceIdentification = "Y";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "V5";
		subject.ServiceCommitmentTypeCode = "E";
		subject.LoadEmptyStatusCode = "U";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "wZ";
		subject.ReferenceIdentification = "Y";
		subject.DateTimePeriodFormatQualifier = "wi";
		subject.IdentificationCode = "V5";
		subject.ServiceCommitmentTypeCode = "E";
		subject.LoadEmptyStatusCode = "U";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V5", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "wZ";
		subject.ReferenceIdentification = "Y";
		subject.DateTimePeriodFormatQualifier = "wi";
		subject.DateTimePeriod = "k";
		subject.ServiceCommitmentTypeCode = "E";
		subject.LoadEmptyStatusCode = "U";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredServiceCommitmentTypeCode(string serviceCommitmentTypeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "wZ";
		subject.ReferenceIdentification = "Y";
		subject.DateTimePeriodFormatQualifier = "wi";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "V5";
		subject.LoadEmptyStatusCode = "U";
		//Test Parameters
		subject.ServiceCommitmentTypeCode = serviceCommitmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "wZ";
		subject.ReferenceIdentification = "Y";
		subject.DateTimePeriodFormatQualifier = "wi";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "V5";
		subject.ServiceCommitmentTypeCode = "E";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
