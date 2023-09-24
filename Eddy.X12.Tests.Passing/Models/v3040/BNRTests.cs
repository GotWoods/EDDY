using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BNRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNR*Pa*Y*8lJl9s*IeQM*n5*Z5";

		var expected = new BNR_BeginningSegmentForNonconformanceReport()
		{
			TransactionSetPurposeCode = "Pa",
			ReferenceNumber = "Y",
			Date = "8lJl9s",
			Time = "IeQM",
			NonconformanceReportStatusCode = "n5",
			TransactionTypeCode = "Z5",
		};

		var actual = Map.MapObject<BNR_BeginningSegmentForNonconformanceReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pa", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.ReferenceNumber = "Y";
		subject.Date = "8lJl9s";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "Pa";
		subject.Date = "8lJl9s";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8lJl9s", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "Pa";
		subject.ReferenceNumber = "Y";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
