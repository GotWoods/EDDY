using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BNRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNR*3E*H*lKg7n5*SJjX*NS*HF";

		var expected = new BNR_BeginningSegmentForNonconformanceReport()
		{
			TransactionSetPurposeCode = "3E",
			ReferenceIdentification = "H",
			Date = "lKg7n5",
			Time = "SJjX",
			NonconformanceReportStatusCode = "NS",
			TransactionTypeCode = "HF",
		};

		var actual = Map.MapObject<BNR_BeginningSegmentForNonconformanceReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3E", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.ReferenceIdentification = "H";
		subject.Date = "lKg7n5";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "3E";
		subject.Date = "lKg7n5";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lKg7n5", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BNR_BeginningSegmentForNonconformanceReport();
		subject.TransactionSetPurposeCode = "3E";
		subject.ReferenceIdentification = "H";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
