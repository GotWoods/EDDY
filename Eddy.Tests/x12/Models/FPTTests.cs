using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FPT*W5*7";

		var expected = new FPT_FinancialParticipation()
		{
			TypeOfAccountCode = "W5",
			PercentageAsDecimal = 7,
		};

		var actual = Map.MapObject<FPT_FinancialParticipation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W5", true)]
	public void Validation_RequiredTypeOfAccountCode(string typeOfAccountCode, bool isValidExpected)
	{
		var subject = new FPT_FinancialParticipation();
		subject.TypeOfAccountCode = typeOfAccountCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
