using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIA*k4*q8*r*BP97etqc*sTnd*L";

		var expected = new BIA_BeginningSegmentForInventoryInquiryAdvice()
		{
			TransactionSetPurposeCode = "k4",
			ReportTypeCode = "q8",
			ReferenceIdentification = "r",
			Date = "BP97etqc",
			Time = "sTnd",
			ActionCode = "L",
		};

		var actual = Map.MapObject<BIA_BeginningSegmentForInventoryInquiryAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k4", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.ReportTypeCode = "q8";
		subject.ReferenceIdentification = "r";
		subject.Date = "BP97etqc";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q8", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "k4";
		subject.ReferenceIdentification = "r";
		subject.Date = "BP97etqc";
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "k4";
		subject.ReportTypeCode = "q8";
		subject.Date = "BP97etqc";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BP97etqc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "k4";
		subject.ReportTypeCode = "q8";
		subject.ReferenceIdentification = "r";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
