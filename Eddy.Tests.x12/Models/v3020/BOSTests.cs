using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOS*0*eUpg3y*TE*9QincY*yg";

		var expected = new BOS_BeginningSegmentForTheOperatingExpenseStatement()
		{
			StatementNumber = "0",
			Date = "eUpg3y",
			AgencyQualifierCode = "TE",
			StatementFormatCode = "9QincY",
			TransactionTypeCode = "yg",
		};

		var actual = Map.MapObject<BOS_BeginningSegmentForTheOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.Date = "eUpg3y";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eUpg3y", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "0";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
