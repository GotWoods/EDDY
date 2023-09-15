using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIA*E2*Rv*u*Iq4OuO*22qI";

		var expected = new BIA_BeginningSegmentForInventoryInquiryAdvice()
		{
			TransactionSetPurposeCode = "E2",
			ReportTypeCode = "Rv",
			ReferenceNumber = "u",
			Date = "Iq4OuO",
			Time = "22qI",
		};

		var actual = Map.MapObject<BIA_BeginningSegmentForInventoryInquiryAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E2", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.ReportTypeCode = "Rv";
		subject.ReferenceNumber = "u";
		subject.Date = "Iq4OuO";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rv", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "E2";
		subject.ReferenceNumber = "u";
		subject.Date = "Iq4OuO";
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "E2";
		subject.ReportTypeCode = "Rv";
		subject.Date = "Iq4OuO";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iq4OuO", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIA_BeginningSegmentForInventoryInquiryAdvice();
		subject.TransactionSetPurposeCode = "E2";
		subject.ReportTypeCode = "Rv";
		subject.ReferenceNumber = "u";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
