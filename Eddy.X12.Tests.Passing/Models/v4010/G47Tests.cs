using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G47Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G47*9yf8GtD6*Q";

		var expected = new G47_StatementIdentification()
		{
			Date = "9yf8GtD6",
			StatementNumber = "Q",
		};

		var actual = Map.MapObject<G47_StatementIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9yf8GtD6", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G47_StatementIdentification();
		subject.StatementNumber = "Q";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new G47_StatementIdentification();
		subject.Date = "9yf8GtD6";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
