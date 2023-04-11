using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G49Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G49*I*j*l";

		var expected = new G49_StatementTotal()
		{
			Amount = "I",
			Amount2 = "j",
			Amount3 = "l",
		};

		var actual = Map.MapObject<G49_StatementTotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new G49_StatementTotal();
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
