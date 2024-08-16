using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C953Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:f:P:Y";

		var expected = new C953_ContributionType()
		{
			ContributionTypeCoded = "6",
			CodeListQualifier = "f",
			CodeListResponsibleAgencyCoded = "P",
			ContributionType = "Y",
		};

		var actual = Map.MapComposite<C953_ContributionType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredContributionTypeCoded(string contributionTypeCoded, bool isValidExpected)
	{
		var subject = new C953_ContributionType();
		//Required fields
		//Test Parameters
		subject.ContributionTypeCoded = contributionTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
