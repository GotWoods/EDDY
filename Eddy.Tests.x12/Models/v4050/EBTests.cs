using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class EBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EB*D*Znm*A*0*W*t*4*7*wE*3*K*4**";

		var expected = new EB_EligibilityOrBenefitInformation()
		{
			EligibilityOrBenefitInformationCode = "D",
			CoverageLevelCode = "Znm",
			ServiceTypeCode = "A",
			InsuranceTypeCode = "0",
			PlanCoverageDescription = "W",
			TimePeriodQualifier = "t",
			MonetaryAmount = 4,
			PercentageAsDecimal = 7,
			QuantityQualifier = "wE",
			Quantity = 3,
			YesNoConditionOrResponseCode = "K",
			YesNoConditionOrResponseCode2 = "4",
			CompositeMedicalProcedureIdentifier = null,
			CompositeDiagnosisCodePointer = null,
		};

		var actual = Map.MapObject<EB_EligibilityOrBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredEligibilityOrBenefitInformationCode(string eligibilityOrBenefitInformationCode, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		//Test Parameters
		subject.EligibilityOrBenefitInformationCode = eligibilityOrBenefitInformationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "wE";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("wE", 3, true)]
	[InlineData("wE", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformationCode = "D";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
