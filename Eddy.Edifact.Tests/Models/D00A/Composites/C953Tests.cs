using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C953Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:c:T:y";

		var expected = new C953_ContributionType()
		{
			ContributionTypeDescriptionCode = "a",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "T",
			ContributionTypeDescription = "y",
		};

		var actual = Map.MapComposite<C953_ContributionType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredContributionTypeDescriptionCode(string contributionTypeDescriptionCode, bool isValidExpected)
	{
		var subject = new C953_ContributionType();
		//Required fields
		//Test Parameters
		subject.ContributionTypeDescriptionCode = contributionTypeDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
