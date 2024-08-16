using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E016Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:7";

		var expected = new E016_InsuranceCoverRequirement()
		{
			InsuranceCoverTypeCode = "w",
			RequirementDesignatorCode = "7",
		};

		var actual = Map.MapComposite<E016_InsuranceCoverRequirement>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredInsuranceCoverTypeCode(string insuranceCoverTypeCode, bool isValidExpected)
	{
		var subject = new E016_InsuranceCoverRequirement();
		//Required fields
		//Test Parameters
		subject.InsuranceCoverTypeCode = insuranceCoverTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
