using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIA*Do*Er*J*SBY1MtfF*tHy8*C";

		var expected = new BIA_BeginningSegmentForInventoryInquiryAdvice()
		{
			TransactionSetPurposeCode = "Do",
			ReportTypeCode = "Er",
			ReferenceIdentification = "J",
			Date = "SBY1MtfF",
			Time = "tHy8",
			ActionCode = "C",
		};

		var actual = Map.MapObject<BIA_BeginningSegmentForInventoryInquiryAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Do", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.ReportTypeCode = "Er";
		subject.ReferenceIdentification = "J";
		subject.Date = "SBY1MtfF";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Er", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "Do";
		subject.ReferenceIdentification = "J";
		subject.Date = "SBY1MtfF";
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "Do";
		subject.ReportTypeCode = "Er";
		subject.Date = "SBY1MtfF";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SBY1MtfF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "Do";
		subject.ReportTypeCode = "Er";
		subject.ReferenceIdentification = "J";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
