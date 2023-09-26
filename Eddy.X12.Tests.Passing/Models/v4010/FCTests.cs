using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class FCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FC*Fl*9*8*9*V";

		var expected = new FC_FinancialContribution()
		{
			ContributionCode = "Fl",
			Percent = 9,
			MonetaryAmount = 8,
			Number = 9,
			YesNoConditionOrResponseCode = "V",
		};

		var actual = Map.MapObject<FC_FinancialContribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fl", true)]
	public void Validation_RequiredContributionCode(string contributionCode, bool isValidExpected)
	{
		var subject = new FC_FinancialContribution();
		//Required fields
		//Test Parameters
		subject.ContributionCode = contributionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
