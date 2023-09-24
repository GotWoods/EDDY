using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTR*3E*q9gFieRS*AaWf*nQ*z*z*HB*JwJ7";

		var expected = new BTR_BeginningSegmentForTestResults()
		{
			TransactionSetPurposeCode = "3E",
			Date = "q9gFieRS",
			Time = "AaWf",
			ReportTypeCode = "nQ",
			ReferenceIdentification = "z",
			ReferenceIdentification2 = "z",
			SecurityLevelCode = "HB",
			HierarchicalStructureCode = "JwJ7",
		};

		var actual = Map.MapObject<BTR_BeginningSegmentForTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3E", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.Date = "q9gFieRS";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q9gFieRS", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.TransactionSetPurposeCode = "3E";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
