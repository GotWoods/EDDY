using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class COTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "COT+S++++";

		var expected = new COT_ContributionDetails()
		{
			ContributionQualifier = "S",
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
	[InlineData("S", true)]
	public void Validation_RequiredContributionQualifier(string contributionQualifier, bool isValidExpected)
	{
		var subject = new COT_ContributionDetails();
		//Required fields
		//Test Parameters
		subject.ContributionQualifier = contributionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
