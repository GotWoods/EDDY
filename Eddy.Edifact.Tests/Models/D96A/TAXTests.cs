using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TAX+3+++U++5+k";

		var expected = new TAX_DutyTaxFeeDetails()
		{
			DutyTaxFeeFunctionQualifier = "3",
			DutyTaxFeeType = null,
			DutyTaxFeeAccountDetail = null,
			DutyTaxFeeAssessmentBasis = "U",
			DutyTaxFeeDetail = null,
			DutyTaxFeeCategoryCoded = "5",
			PartyTaxIdentificationNumber = "k",
		};

		var actual = Map.MapObject<TAX_DutyTaxFeeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredDutyTaxFeeFunctionQualifier(string dutyTaxFeeFunctionQualifier, bool isValidExpected)
	{
		var subject = new TAX_DutyTaxFeeDetails();
		//Required fields
		//Test Parameters
		subject.DutyTaxFeeFunctionQualifier = dutyTaxFeeFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
