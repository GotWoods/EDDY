using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BNRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNR*Fd*h*fgHRbI*VLih*w3";

		var expected = new BNR_BeginningSegmentForNonconformanceReport()
		{
			TransactionSetPurposeCode = "Fd",
			ReferenceNumber = "h",
			Date = "fgHRbI",
			Time = "VLih",
			NonconformanceReportStatusCode = "w3",
		};

		var actual = Map.MapObject<BNR_BeginningSegmentForNonconformanceReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fd", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.ReferenceNumber = "h";
		subject.Date = "fgHRbI";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "Fd";
		subject.Date = "fgHRbI";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fgHRbI", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "Fd";
		subject.ReferenceNumber = "h";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
