using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class COTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "COT+U++++";

		var expected = new COT_ContributionDetails()
		{
			ContributionCodeQualifier = "U",
			ContributionType = null,
			Instruction = null,
			RateTariffClass = null,
			ReasonForChange = null,
		};

		var actual = Map.MapObject<COT_ContributionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredContributionCodeQualifier(string contributionCodeQualifier, bool isValidExpected)
	{
		var subject = new COT_ContributionDetails();
		//Required fields
		//Test Parameters
		subject.ContributionCodeQualifier = contributionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
