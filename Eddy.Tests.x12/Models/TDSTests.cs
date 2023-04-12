using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TDS*R*D*I*3";

		var expected = new TDS_TotalMonetaryValueSummary()
		{
			Amount = "R",
			Amount2 = "D",
			Amount3 = "I",
			Amount4 = "3",
		};

		var actual = Map.MapObject<TDS_TotalMonetaryValueSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new TDS_TotalMonetaryValueSummary();
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
