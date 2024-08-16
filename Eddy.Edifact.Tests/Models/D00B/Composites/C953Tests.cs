using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C953Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "J:T:L:W";

		var expected = new C953_ContributionType()
		{
			ContributionTypeDescriptionCode = "J",
			CodeListIdentificationCode = "T",
			CodeListResponsibleAgencyCode = "L",
			ContributionTypeDescription = "W",
		};

		var actual = Map.MapComposite<C953_ContributionType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredContributionTypeDescriptionCode(string contributionTypeDescriptionCode, bool isValidExpected)
	{
		var subject = new C953_ContributionType();
		//Required fields
		//Test Parameters
		subject.ContributionTypeDescriptionCode = contributionTypeDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
