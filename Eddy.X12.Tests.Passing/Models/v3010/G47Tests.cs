using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G47Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G47*VSgpgS*y";

		var expected = new G47_StatementIdentification()
		{
			Date = "VSgpgS",
			StatementNumber = "y",
		};

		var actual = Map.MapObject<G47_StatementIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VSgpgS", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G47_StatementIdentification();
		subject.StatementNumber = "y";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredStatementNumber(string statementNumber, bool isValidExpected)
	{
		var subject = new G47_StatementIdentification();
		subject.Date = "VSgpgS";
		subject.StatementNumber = statementNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
