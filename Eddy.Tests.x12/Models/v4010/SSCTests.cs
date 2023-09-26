using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSC*y3*0*VK*k*2f*B*I*3";

		var expected = new SSC_BeginningSegmentForServiceCommitmentAdvice()
		{
			TransactionSetPurposeCode = "y3",
			ReferenceIdentification = "0",
			DateTimePeriodFormatQualifier = "VK",
			DateTimePeriod = "k",
			IdentificationCode = "2f",
			ServiceCommitmentTypeCode = "B",
			LoadEmptyStatusCode = "I",
			Percent = 3,
		};

		var actual = Map.MapObject<SSC_BeginningSegmentForServiceCommitmentAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y3", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.DateTimePeriodFormatQualifier = "VK";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "2f";
		subject.ServiceCommitmentTypeCode = "B";
		subject.LoadEmptyStatusCode = "I";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "y3";
		subject.DateTimePeriodFormatQualifier = "VK";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "2f";
		subject.ServiceCommitmentTypeCode = "B";
		subject.LoadEmptyStatusCode = "I";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VK", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "y3";
		subject.ReferenceIdentification = "0";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "2f";
		subject.ServiceCommitmentTypeCode = "B";
		subject.LoadEmptyStatusCode = "I";
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
		subject.TransactionSetPurposeCode = "y3";
		subject.ReferenceIdentification = "0";
		subject.DateTimePeriodFormatQualifier = "VK";
		subject.IdentificationCode = "2f";
		subject.ServiceCommitmentTypeCode = "B";
		subject.LoadEmptyStatusCode = "I";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2f", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "y3";
		subject.ReferenceIdentification = "0";
		subject.DateTimePeriodFormatQualifier = "VK";
		subject.DateTimePeriod = "k";
		subject.ServiceCommitmentTypeCode = "B";
		subject.LoadEmptyStatusCode = "I";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredServiceCommitmentTypeCode(string serviceCommitmentTypeCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "y3";
		subject.ReferenceIdentification = "0";
		subject.DateTimePeriodFormatQualifier = "VK";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "2f";
		subject.LoadEmptyStatusCode = "I";
		//Test Parameters
		subject.ServiceCommitmentTypeCode = serviceCommitmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new SSC_BeginningSegmentForServiceCommitmentAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "y3";
		subject.ReferenceIdentification = "0";
		subject.DateTimePeriodFormatQualifier = "VK";
		subject.DateTimePeriod = "k";
		subject.IdentificationCode = "2f";
		subject.ServiceCommitmentTypeCode = "B";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
