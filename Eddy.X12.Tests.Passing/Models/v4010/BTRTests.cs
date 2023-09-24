using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTR*6r*6WfYId14*7Ega*Nj*6*0*7j";

		var expected = new BTR_BeginningSegmentForTestResults()
		{
			TransactionSetPurposeCode = "6r",
			Date = "6WfYId14",
			Time = "7Ega",
			ReportTypeCode = "Nj",
			ReferenceIdentification = "6",
			ReferenceIdentification2 = "0",
			SecurityLevelCode = "7j",
		};

		var actual = Map.MapObject<BTR_BeginningSegmentForTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6r", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.Date = "6WfYId14";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6WfYId14", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.TransactionSetPurposeCode = "6r";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
