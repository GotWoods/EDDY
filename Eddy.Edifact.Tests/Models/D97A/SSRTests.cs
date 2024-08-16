using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class SSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SSR++";

		var expected = new SSR_SpecialRequirementDetails()
		{
			SpecialRequirementTypeDetails = null,
			SpecialRequirementDetails = null,
		};

		var actual = Map.MapObject<SSR_SpecialRequirementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSpecialRequirementTypeDetails(string specialRequirementTypeDetails, bool isValidExpected)
	{
		var subject = new SSR_SpecialRequirementDetails();
		//Required fields
		//Test Parameters
		if (specialRequirementTypeDetails != "") 
			subject.SpecialRequirementTypeDetails = new E980_SpecialRequirementTypeDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
