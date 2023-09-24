using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G47Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G47*QWiSseLD*9";

		var expected = new G47_StatementIdentification()
		{
			Date = "QWiSseLD",
			StatementNumber = "9",
		};

		var actual = Map.MapObject<G47_StatementIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QWiSseLD", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G47_StatementIdentification();
		subject.StatementNumber = "9";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new G47_StatementIdentification();
		subject.Date = "QWiSseLD";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
