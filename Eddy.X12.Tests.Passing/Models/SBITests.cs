using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBI*h*m*8*8*3*9*6*h*E*x*5";

		var expected = new SBI_SpecificBenefitInformation()
		{
			EligibilityOrBenefitInformationCode = "h",
			TimePeriodQualifier = "m",
			NumberOfPeriods = 8,
			PercentageAsDecimal = 8,
			MonetaryAmount = 3,
			MonetaryAmount2 = 9,
			TierIdentifier = 6,
			PlanCoverageDescription = "h",
			YesNoConditionOrResponseCode = "E",
			YesNoConditionOrResponseCode2 = "x",
			MonetaryAmount3 = 5,
		};

		var actual = Map.MapObject<SBI_SpecificBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEligibilityOrBenefitInformationCode(string eligibilityOrBenefitInformationCode, bool isValidExpected)
	{
		var subject = new SBI_SpecificBenefitInformation();
		subject.EligibilityOrBenefitInformationCode = eligibilityOrBenefitInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "m", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new SBI_SpecificBenefitInformation();
		subject.EligibilityOrBenefitInformationCode = "h";
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;
		subject.TimePeriodQualifier = timePeriodQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
