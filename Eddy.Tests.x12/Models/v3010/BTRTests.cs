using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTR*iQ*PMAtbY*X3Sh*Vx*z*e";

		var expected = new BTR_BeginningSegmentForTestResults()
		{
			TransactionSetPurposeCode = "iQ",
			Date = "PMAtbY",
			Time = "X3Sh",
			ReportTypeCode = "Vx",
			ReferenceNumber = "z",
			ReferenceNumber2 = "e",
		};

		var actual = Map.MapObject<BTR_BeginningSegmentForTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iQ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.Date = "PMAtbY";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PMAtbY", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.TransactionSetPurposeCode = "iQ";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
