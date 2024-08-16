using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TAX+H+++P++3+N+r";

		var expected = new TAX_DutyTaxFeeDetails()
		{
			DutyOrTaxOrFeeFunctionCodeQualifier = "H",
			DutyTaxFeeType = null,
			DutyTaxFeeAccountDetail = null,
			DutyOrTaxOrFeeAssessmentBasisQuantity = "P",
			DutyTaxFeeDetail = null,
			DutyOrTaxOrFeeCategoryCode = "3",
			PartyTaxIdentifier = "N",
			CalculationSequenceCode = "r",
		};

		var actual = Map.MapObject<TAX_DutyTaxFeeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredDutyOrTaxOrFeeFunctionCodeQualifier(string dutyOrTaxOrFeeFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new TAX_DutyTaxFeeDetails();
		//Required fields
		//Test Parameters
		subject.DutyOrTaxOrFeeFunctionCodeQualifier = dutyOrTaxOrFeeFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
