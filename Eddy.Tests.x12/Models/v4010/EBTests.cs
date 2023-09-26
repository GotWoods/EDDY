using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class EBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EB*J*6sh*Y*m*H*b*9*5*O5*2*6*s*";

		var expected = new EB_EligibilityOrBenefitInformation()
		{
			EligibilityOrBenefitInformation = "J",
			CoverageLevelCode = "6sh",
			ServiceTypeCode = "Y",
			InsuranceTypeCode = "m",
			PlanCoverageDescription = "H",
			TimePeriodQualifier = "b",
			MonetaryAmount = 9,
			Percent = 5,
			QuantityQualifier = "O5",
			Quantity = 2,
			YesNoConditionOrResponseCode = "6",
			YesNoConditionOrResponseCode2 = "s",
			CompositeMedicalProcedureIdentifier = null,
		};

		var actual = Map.MapObject<EB_EligibilityOrBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredEligibilityOrBenefitInformation(string eligibilityOrBenefitInformation, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		//Test Parameters
		subject.EligibilityOrBenefitInformation = eligibilityOrBenefitInformation;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "O5";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O5", 2, true)]
	[InlineData("O5", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EB_EligibilityOrBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformation = "J";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
