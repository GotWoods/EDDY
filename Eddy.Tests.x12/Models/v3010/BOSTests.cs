using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOS*t*TWEaXq*1N*d2jTwt*ce";

		var expected = new BOS_BeginningSegmentForTheOperatingExpenseStatement()
		{
			StatementNumber = "t",
			Date = "TWEaXq",
			AssociationQualifierCode = "1N",
			StatementFormatCode = "d2jTwt",
			TransactionTypeCode = "ce",
		};

		var actual = Map.MapObject<BOS_BeginningSegmentForTheOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.Date = "TWEaXq";
		subject.AssociationQualifierCode = "1N";
		subject.StatementFormatCode = "d2jTwt";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TWEaXq", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "t";
		subject.AssociationQualifierCode = "1N";
		subject.StatementFormatCode = "d2jTwt";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1N", true)]
	public void Validation_RequiredAssociationQualifierCode(string associationQualifierCode, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "t";
		subject.Date = "TWEaXq";
		subject.StatementFormatCode = "d2jTwt";
		subject.AssociationQualifierCode = associationQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d2jTwt", true)]
	public void Validation_RequiredStatementFormatCode(string statementFormatCode, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "t";
		subject.Date = "TWEaXq";
		subject.AssociationQualifierCode = "1N";
		subject.StatementFormatCode = statementFormatCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
