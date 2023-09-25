using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class FCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FC*09*1*2*3*d";

		var expected = new FC_FinancialContribution()
		{
			ContributionCode = "09",
			PercentageAsDecimal = 1,
			MonetaryAmount = 2,
			Number = 3,
			YesNoConditionOrResponseCode = "d",
		};

		var actual = Map.MapObject<FC_FinancialContribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("09", true)]
	public void Validation_RequiredContributionCode(string contributionCode, bool isValidExpected)
	{
		var subject = new FC_FinancialContribution();
		//Required fields
		//Test Parameters
		subject.ContributionCode = contributionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
