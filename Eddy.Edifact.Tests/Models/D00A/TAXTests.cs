using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TAX+x+++W++N+1+U";

		var expected = new TAX_DutyTaxFeeDetails()
		{
			DutyOrTaxOrFeeFunctionCodeQualifier = "x",
			DutyTaxFeeType = null,
			DutyTaxFeeAccountDetail = null,
			DutyOrTaxOrFeeAssessmentBasisValue = "W",
			DutyTaxFeeDetail = null,
			DutyOrTaxOrFeeCategoryCode = "N",
			PartyTaxIdentifier = "1",
			CalculationSequenceCode = "U",
		};

		var actual = Map.MapObject<TAX_DutyTaxFeeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredDutyOrTaxOrFeeFunctionCodeQualifier(string dutyOrTaxOrFeeFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new TAX_DutyTaxFeeDetails();
		//Required fields
		//Test Parameters
		subject.DutyOrTaxOrFeeFunctionCodeQualifier = dutyOrTaxOrFeeFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
