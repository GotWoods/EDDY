using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIA*HE*l2*0*VekN1G*51Si*s";

		var expected = new BIA_BeginningSegmentForInventoryInquiryAdvice()
		{
			TransactionSetPurposeCode = "HE",
			ReportTypeCode = "l2",
			ReferenceIdentification = "0",
			Date = "VekN1G",
			Time = "51Si",
			ActionCode = "s",
		};

		var actual = Map.MapObject<BIA_BeginningSegmentForInventoryInquiryAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HE", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.ReportTypeCode = "l2";
		subject.ReferenceIdentification = "0";
		subject.Date = "VekN1G";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l2", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "HE";
		subject.ReferenceIdentification = "0";
		subject.Date = "VekN1G";
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "HE";
		subject.ReportTypeCode = "l2";
		subject.Date = "VekN1G";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VekN1G", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "HE";
		subject.ReportTypeCode = "l2";
		subject.ReferenceIdentification = "0";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
