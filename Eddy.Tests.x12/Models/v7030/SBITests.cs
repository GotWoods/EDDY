using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class SBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBI*v*K*7*5*4*5*5*p*L*5*7";

		var expected = new SBI_SpecificBenefitInformation()
		{
			EligibilityOrBenefitInformationCode = "v",
			TimePeriodQualifier = "K",
			NumberOfPeriods = 7,
			PercentageAsDecimal = 5,
			MonetaryAmount = 4,
			MonetaryAmount2 = 5,
			TierIdentifier = 5,
			PlanCoverageDescription = "p",
			YesNoConditionOrResponseCode = "L",
			YesNoConditionOrResponseCode2 = "5",
			MonetaryAmount3 = 7,
		};

		var actual = Map.MapObject<SBI_SpecificBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredEligibilityOrBenefitInformationCode(string eligibilityOrBenefitInformationCode, bool isValidExpected)
	{
		var subject = new SBI_SpecificBenefitInformation();
		//Required fields
		//Test Parameters
		subject.EligibilityOrBenefitInformationCode = eligibilityOrBenefitInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "K", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "K", true)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new SBI_SpecificBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformationCode = "v";
		//Test Parameters
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
