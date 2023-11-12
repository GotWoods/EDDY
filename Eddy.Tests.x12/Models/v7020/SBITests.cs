using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class SBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBI*3*c*6*9*6*6*9*I*4*V";

		var expected = new SBI_SpecificBenefitInformation()
		{
			EligibilityOrBenefitInformationCode = "3",
			TimePeriodQualifier = "c",
			NumberOfPeriods = 6,
			PercentageAsDecimal = 9,
			MonetaryAmount = 6,
			MonetaryAmount2 = 6,
			TierIdentifier = 9,
			PlanCoverageDescription = "I",
			YesNoConditionOrResponseCode = "4",
			YesNoConditionOrResponseCode2 = "V",
		};

		var actual = Map.MapObject<SBI_SpecificBenefitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredEligibilityOrBenefitInformationCode(string eligibilityOrBenefitInformationCode, bool isValidExpected)
	{
		var subject = new SBI_SpecificBenefitInformation();
		//Required fields
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.EligibilityOrBenefitInformationCode = eligibilityOrBenefitInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "c", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "c", true)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new SBI_SpecificBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformationCode = "3";
		subject.MonetaryAmount = 6;
		//Test Parameters
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SBI_SpecificBenefitInformation();
		//Required fields
		subject.EligibilityOrBenefitInformationCode = "3";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
