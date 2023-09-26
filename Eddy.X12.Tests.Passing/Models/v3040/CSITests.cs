using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSI*iO*EIq*x3*D";

		var expected = new CSI_ClaimStatusInformation()
		{
			ClaimSubmissionReasonCode = "iO",
			DateTimeQualifier = "EIq",
			DateTimePeriodFormatQualifier = "x3",
			DateTimePeriod = "D",
		};

		var actual = Map.MapObject<CSI_ClaimStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iO", true)]
	public void Validation_RequiredClaimSubmissionReasonCode(string claimSubmissionReasonCode, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		//Required fields
		subject.DateTimeQualifier = "EIq";
		subject.DateTimePeriodFormatQualifier = "x3";
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.ClaimSubmissionReasonCode = claimSubmissionReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EIq", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		//Required fields
		subject.ClaimSubmissionReasonCode = "iO";
		subject.DateTimePeriodFormatQualifier = "x3";
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x3", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		//Required fields
		subject.ClaimSubmissionReasonCode = "iO";
		subject.DateTimeQualifier = "EIq";
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		//Required fields
		subject.ClaimSubmissionReasonCode = "iO";
		subject.DateTimeQualifier = "EIq";
		subject.DateTimePeriodFormatQualifier = "x3";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
