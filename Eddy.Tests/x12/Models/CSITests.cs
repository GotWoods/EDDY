using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSI*oQ*4zo*F4*R";

		var expected = new CSI_ClaimStatusInformation()
		{
			ClaimSubmissionReasonCode = "oQ",
			DateTimeQualifier = "4zo",
			DateTimePeriodFormatQualifier = "F4",
			DateTimePeriod = "R",
		};

		var actual = Map.MapObject<CSI_ClaimStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oQ", true)]
	public void Validatation_RequiredClaimSubmissionReasonCode(string claimSubmissionReasonCode, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		subject.DateTimeQualifier = "4zo";
		subject.DateTimePeriodFormatQualifier = "F4";
		subject.DateTimePeriod = "R";
		subject.ClaimSubmissionReasonCode = claimSubmissionReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4zo", true)]
	public void Validatation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		subject.ClaimSubmissionReasonCode = "oQ";
		subject.DateTimePeriodFormatQualifier = "F4";
		subject.DateTimePeriod = "R";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F4", true)]
	public void Validatation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		subject.ClaimSubmissionReasonCode = "oQ";
		subject.DateTimeQualifier = "4zo";
		subject.DateTimePeriod = "R";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CSI_ClaimStatusInformation();
		subject.ClaimSubmissionReasonCode = "oQ";
		subject.DateTimeQualifier = "4zo";
		subject.DateTimePeriodFormatQualifier = "F4";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
