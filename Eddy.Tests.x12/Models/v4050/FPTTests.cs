using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class FPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FPT*7L*7";

		var expected = new FPT_FinancialParticipation()
		{
			TypeOfAccountCode = "7L",
			PercentageAsDecimal = 7,
		};

		var actual = Map.MapObject<FPT_FinancialParticipation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7L", true)]
	public void Validation_RequiredTypeOfAccountCode(string typeOfAccountCode, bool isValidExpected)
	{
		var subject = new FPT_FinancialParticipation();
		//Required fields
		//Test Parameters
		subject.TypeOfAccountCode = typeOfAccountCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
