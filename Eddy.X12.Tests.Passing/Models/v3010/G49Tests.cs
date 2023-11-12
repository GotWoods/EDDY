using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G49Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G49*8*C3*QY";

		var expected = new G49_StatementTotal()
		{
			TotalStatementAmount = "8",
			PriorBalance = "C3",
			CurrentBalance = "QY",
		};

		var actual = Map.MapObject<G49_StatementTotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredTotalStatementAmount(string totalStatementAmount, bool isValidExpected)
	{
		var subject = new G49_StatementTotal();
		subject.TotalStatementAmount = totalStatementAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
