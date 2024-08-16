using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E016Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "7:r";

		var expected = new E016_InsuranceCoverRequirement()
		{
			InsuranceCoverTypeCode = "7",
			RequirementDesignatorCoded = "r",
		};

		var actual = Map.MapComposite<E016_InsuranceCoverRequirement>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredInsuranceCoverTypeCode(string insuranceCoverTypeCode, bool isValidExpected)
	{
		var subject = new E016_InsuranceCoverRequirement();
		//Required fields
		//Test Parameters
		subject.InsuranceCoverTypeCode = insuranceCoverTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
