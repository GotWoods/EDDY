using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BNRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNR*oE*U*NqETdjzl*YwOn*N1*D7";

		var expected = new BNR_BeginningSegmentForNonconformanceReport()
		{
			TransactionSetPurposeCode = "oE",
			ReferenceIdentification = "U",
			Date = "NqETdjzl",
			Time = "YwOn",
			NonconformanceReportStatusCode = "N1",
			TransactionTypeCode = "D7",
		};

		var actual = Map.MapObject<BNR_BeginningSegmentForNonconformanceReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oE", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.ReferenceIdentification = "U";
		subject.Date = "NqETdjzl";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "oE";
		subject.Date = "NqETdjzl";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NqETdjzl", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "oE";
		subject.ReferenceIdentification = "U";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
