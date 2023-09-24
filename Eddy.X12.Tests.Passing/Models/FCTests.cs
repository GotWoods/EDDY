using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FC*xp*9*8*3*i";

		var expected = new FC_FinancialContribution()
		{
			ContributionCode = "xp",
			PercentageAsDecimal = 9,
			MonetaryAmount = 8,
			Number = 3,
			YesNoConditionOrResponseCode = "i",
		};

		var actual = Map.MapObject<FC_FinancialContribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xp", true)]
	public void Validation_RequiredContributionCode(string contributionCode, bool isValidExpected)
	{
		var subject = new FC_FinancialContribution();
		subject.ContributionCode = contributionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
