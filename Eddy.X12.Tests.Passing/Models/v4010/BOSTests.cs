using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOS*Q*LYzAhP9o*vB*KA1ztJ*kA*jLqe4vD8";

		var expected = new BOS_BeginningSegmentForTheOperatingExpenseStatement()
		{
			StatementNumber = "Q",
			Date = "LYzAhP9o",
			AgencyQualifierCode = "vB",
			StatementFormatCode = "KA1ztJ",
			TransactionTypeCode = "kA",
			Date2 = "jLqe4vD8",
		};

		var actual = Map.MapObject<BOS_BeginningSegmentForTheOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.Date = "LYzAhP9o";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LYzAhP9o", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "Q";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
