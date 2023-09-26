using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FC*aN*4*3";

		var expected = new FC_FinancialContribution()
		{
			ContributionCode = "aN",
			Percent = 4,
			MonetaryAmount = 3,
		};

		var actual = Map.MapObject<FC_FinancialContribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aN", true)]
	public void Validation_RequiredContributionCode(string contributionCode, bool isValidExpected)
	{
		var subject = new FC_FinancialContribution();
		//Required fields
		//Test Parameters
		subject.ContributionCode = contributionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
