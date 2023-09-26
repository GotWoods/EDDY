using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class EBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EB*G*5BV**w*p*8*2*2*BJ*8*p*L**4*C*r*";

		var expected = new EB_EligibilityOrBenefitInformation()
		{
			EligibilityOrBenefitInformationCode = "G",
			CoverageLevelCode = "5BV",
			ServiceType = null,
			InsuranceProductCode = "w",
			PlanCoverageDescription = "p",
			TimePeriodQualifier = "8",
			MonetaryAmount = 2,
			PercentageAsDecimal = 2,
			QuantityQualifier = "BJ",
			Quantity = 8,
			YesNoConditionOrResponseCode = "p",
			NetworkIndicatorCode = "L",
			CompositeMedicalProcedureIdentifier = null,
			DiagnosisCodePointer = 4,
			YesNoConditionOrResponseCode2 = "C",
			HealthCareServicesReviewRequirementCode = "r",
			HealthCareCodeInformation = null,
		};

		var actual = Map.MapObject<EB_EligibilityOrBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredEligibilityOrBenefitInformationCode(string eligibilityOrBenefitInformationCode, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		//Test Parameters
		subject.EligibilityOrBenefitInformationCode = eligibilityOrBenefitInformationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "BJ";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("BJ", 8, true)]
	[InlineData("BJ", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformationCode = "G";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
