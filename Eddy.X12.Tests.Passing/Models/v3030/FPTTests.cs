using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FPT*3O*5";

		var expected = new FPT_FinancialParticipation()
		{
			TypeOfAccount = "3O",
			Percent = 5,
		};

		var actual = Map.MapObject<FPT_FinancialParticipation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3O", true)]
	public void Validation_RequiredTypeOfAccount(string typeOfAccount, bool isValidExpected)
	{
		var subject = new FPT_FinancialParticipation();
		//Required fields
		//Test Parameters
		subject.TypeOfAccount = typeOfAccount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
