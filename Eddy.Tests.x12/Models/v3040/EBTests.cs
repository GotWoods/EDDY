using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class EBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EB*Z*7dW*1*r*H*5*2*8*Zd*4*7*K*";

		var expected = new EB_EligibilityOrBenefitInformation()
		{
			EligibilityOrBenefitInformation = "Z",
			CoverageLevelCode = "7dW",
			ServiceTypeCode = "1",
			InsuranceTypeCode = "r",
			PlanCoverageDescription = "H",
			TimePeriodQualifier = "5",
			MonetaryAmount = 2,
			Percent = 8,
			QuantityQualifier = "Zd",
			Quantity = 4,
			YesNoConditionOrResponseCode = "7",
			YesNoConditionOrResponseCode2 = "K",
			CompositeMedicalProcedureIdentifier = null,
		};

		var actual = Map.MapObject<EB_EligibilityOrBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEligibilityOrBenefitInformation(string eligibilityOrBenefitInformation, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		//Test Parameters
		subject.EligibilityOrBenefitInformation = eligibilityOrBenefitInformation;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "Zd";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Zd", 4, true)]
	[InlineData("Zd", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformation = "Z";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
