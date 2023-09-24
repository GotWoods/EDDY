using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EB*9*JuV**w*X*P*5*5*8M*7*y*M**2*o*a*";

		var expected = new EB_EligibilityOrBenefitInformation()
		{
			EligibilityOrBenefitInformationCode = "9",
			CoverageLevelCode = "JuV",
			ServiceType = null,
			InsuranceProductCode = "w",
			PlanCoverageDescription = "X",
			TimePeriodQualifier = "P",
			MonetaryAmount = 5,
			PercentageAsDecimal = 5,
			QuantityQualifier = "8M",
			Quantity = 7,
			YesNoConditionOrResponseCode = "y",
			NetworkIndicatorCode = "M",
			CompositeMedicalProcedureIdentifier = null,
			DiagnosisCodePointer = 2,
			YesNoConditionOrResponseCode2 = "o",
			HealthCareServicesReviewRequirementCode = "a",
			HealthCareCodeInformation = null,
		};

		var actual = Map.MapObject<EB_EligibilityOrBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEligibilityOrBenefitInformationCode(string eligibilityOrBenefitInformationCode, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		subject.EligibilityOrBenefitInformationCode = eligibilityOrBenefitInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("8M", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("8M", 0, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		subject.EligibilityOrBenefitInformationCode = "9";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
