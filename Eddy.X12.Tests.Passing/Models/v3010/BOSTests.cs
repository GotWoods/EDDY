using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOS*h*cWVmBz*T0*KWGQVq*A0";

		var expected = new BOS_BeginningSegmentForTheOperatingExpenseStatement()
		{
			StatementNumber = "h",
			Date = "cWVmBz",
			AssociationQualifierCode = "T0",
			StatementFormatCode = "KWGQVq",
			TransactionTypeCode = "A0",
		};

		var actual = Map.MapObject<BOS_BeginningSegmentForTheOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.Date = "cWVmBz";
		subject.AssociationQualifierCode = "T0";
		subject.StatementFormatCode = "KWGQVq";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cWVmBz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "h";
		subject.AssociationQualifierCode = "T0";
		subject.StatementFormatCode = "KWGQVq";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T0", true)]
	public void Validation_RequiredAssociationQualifierCode(string associationQualifierCode, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "h";
		subject.Date = "cWVmBz";
		subject.StatementFormatCode = "KWGQVq";
		subject.AssociationQualifierCode = associationQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KWGQVq", true)]
	public void Validation_RequiredStatementFormatCode(string statementFormatCode, bool isValidExpected)
	{
		var subject = new BOS_BeginningSegmentForTheOperatingExpenseStatement();
		subject.StatementNumber = "h";
		subject.Date = "cWVmBz";
		subject.AssociationQualifierCode = "T0";
		subject.StatementFormatCode = statementFormatCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
