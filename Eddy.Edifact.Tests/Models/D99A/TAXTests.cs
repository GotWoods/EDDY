using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TAX+n+++y++z+o+O";

		var expected = new TAX_DutyTaxFeeDetails()
		{
			DutyTaxFeeFunctionQualifier = "n",
			DutyTaxFeeType = null,
			DutyTaxFeeAccountDetail = null,
			DutyTaxFeeAssessmentBasis = "y",
			DutyTaxFeeDetail = null,
			DutyTaxFeeCategoryCoded = "z",
			PartyTaxIdentificationNumber = "o",
			CalculationSequenceIndicatorCoded = "O",
		};

		var actual = Map.MapObject<TAX_DutyTaxFeeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredDutyTaxFeeFunctionQualifier(string dutyTaxFeeFunctionQualifier, bool isValidExpected)
	{
		var subject = new TAX_DutyTaxFeeDetails();
		//Required fields
		//Test Parameters
		subject.DutyTaxFeeFunctionQualifier = dutyTaxFeeFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
