using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class EBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EB*x*P9b**A*L*5*7*8*G2*4*i*W**3*t*T";

		var expected = new EB_EligibilityOrBenefitInformation()
		{
			EligibilityOrBenefitInformationCode = "x",
			CoverageLevelCode = "P9b",
			ServiceType = null,
			InsuranceProductCode = "A",
			PlanCoverageDescription = "L",
			TimePeriodQualifier = "5",
			MonetaryAmount = 7,
			PercentageAsDecimal = 8,
			QuantityQualifier = "G2",
			Quantity = 4,
			YesNoConditionOrResponseCode = "i",
			NetworkIndicatorCode = "W",
			CompositeMedicalProcedureIdentifier = null,
			DiagnosisCodePointer = 3,
			YesNoConditionOrResponseCode2 = "t",
			HealthCareServicesReviewRequirementCode = "T",
		};

		var actual = Map.MapObject<EB_EligibilityOrBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredEligibilityOrBenefitInformationCode(string eligibilityOrBenefitInformationCode, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		//Test Parameters
		subject.EligibilityOrBenefitInformationCode = eligibilityOrBenefitInformationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "G2";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("G2", 4, true)]
	[InlineData("G2", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformationCode = "x";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
