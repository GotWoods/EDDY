using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C953Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:K:K:k";

		var expected = new C953_ContributionType()
		{
			ContributionTypeCoded = "7",
			CodeListIdentificationCode = "K",
			CodeListResponsibleAgencyCode = "K",
			ContributionType = "k",
		};

		var actual = Map.MapComposite<C953_ContributionType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredContributionTypeCoded(string contributionTypeCoded, bool isValidExpected)
	{
		var subject = new C953_ContributionType();
		//Required fields
		//Test Parameters
		subject.ContributionTypeCoded = contributionTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
