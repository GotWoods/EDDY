using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTR*Vt*q7dLaBE5*llHH*B2*S*z*on*ZDhx";

		var expected = new BTR_BeginningSegmentForTestResults()
		{
			TransactionSetPurposeCode = "Vt",
			Date = "q7dLaBE5",
			Time = "llHH",
			ReportTypeCode = "B2",
			ReferenceIdentification = "S",
			ReferenceIdentification2 = "z",
			SecurityLevelCode = "on",
			HierarchicalStructureCode = "ZDhx",
		};

		var actual = Map.MapObject<BTR_BeginningSegmentForTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vt", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.Date = "q7dLaBE5";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q7dLaBE5", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTR_BeginningSegmentForTestResults();
		subject.TransactionSetPurposeCode = "Vt";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
