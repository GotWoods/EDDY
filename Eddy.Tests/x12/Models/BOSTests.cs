using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOS*3*OaoIXX5E*X8*VxeyEG*TN*rGMF7FS4";

		var expected = new BOS_BeginningSegmentForJointInterestBillingAndOperatingExpenseStatement()
		{
			StatementNumber = "3",
			Date = "OaoIXX5E",
			AgencyQualifierCode = "X8",
			StatementFormatCode = "VxeyEG",
			TransactionTypeCode = "TN",
			Date2 = "rGMF7FS4",
		};

		var actual = Map.MapObject<BOS_BeginningSegmentForJointInterestBillingAndOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForJointInterestBillingAndOperatingExpenseStatement();
		subject.Date = "OaoIXX5E";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OaoIXX5E", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForJointInterestBillingAndOperatingExpenseStatement();
		subject.StatementNumber = "3";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
