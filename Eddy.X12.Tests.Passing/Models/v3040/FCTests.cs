using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class FCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FC*Zg*7*8*5*v";

		var expected = new FC_FinancialContribution()
		{
			ContributionCode = "Zg",
			Percent = 7,
			MonetaryAmount = 8,
			Number = 5,
			YesNoConditionOrResponseCode = "v",
		};

		var actual = Map.MapObject<FC_FinancialContribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zg", true)]
	public void Validation_RequiredContributionCode(string contributionCode, bool isValidExpected)
	{
		var subject = new FC_FinancialContribution();
		//Required fields
		//Test Parameters
		subject.ContributionCode = contributionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
