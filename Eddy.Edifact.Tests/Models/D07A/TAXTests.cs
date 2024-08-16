using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D07A;
using Eddy.Edifact.Models.D07A.Composites;

namespace Eddy.Edifact.Tests.Models.D07A;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TAX+e+++T++J+z+a+I";

		var expected = new TAX_DutyTaxFeeDetails()
		{
			DutyOrTaxOrFeeFunctionCodeQualifier = "e",
			DutyTaxFeeType = null,
			DutyTaxFeeAccountDetail = null,
			DutyOrTaxOrFeeAssessmentBasisQuantity = "T",
			DutyTaxFeeDetail = null,
			DutyOrTaxOrFeeCategoryCode = "J",
			PartyTaxIdentifier = "z",
			CalculationSequenceCode = "a",
			TaxOrDutyOrFeePaymentDueDateCode = "I",
		};

		var actual = Map.MapObject<TAX_DutyTaxFeeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredDutyOrTaxOrFeeFunctionCodeQualifier(string dutyOrTaxOrFeeFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new TAX_DutyTaxFeeDetails();
		//Required fields
		//Test Parameters
		subject.DutyOrTaxOrFeeFunctionCodeQualifier = dutyOrTaxOrFeeFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
