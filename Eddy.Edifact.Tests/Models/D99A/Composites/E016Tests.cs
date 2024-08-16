using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E016Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:c";

		var expected = new E016_InsuranceCoverRequirement()
		{
			InsuranceCoverTypeCoded = "S",
			RequirementDesignatorCoded = "c",
		};

		var actual = Map.MapComposite<E016_InsuranceCoverRequirement>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredInsuranceCoverTypeCoded(string insuranceCoverTypeCoded, bool isValidExpected)
	{
		var subject = new E016_InsuranceCoverRequirement();
		//Required fields
		//Test Parameters
		subject.InsuranceCoverTypeCoded = insuranceCoverTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
