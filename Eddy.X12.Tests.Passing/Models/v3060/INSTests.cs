using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class INSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INS*V*FL*HPx*jS*D*4*J*GB*P*I*Xc*i*o*Xy*r7*BH*8";

		var expected = new INS_InsuredBenefit()
		{
			YesNoConditionOrResponseCode = "V",
			IndividualRelationshipCode = "FL",
			MaintenanceTypeCode = "HPx",
			MaintenanceReasonCode = "jS",
			BenefitStatusCode = "D",
			MedicarePlanCode = "4",
			ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode = "J",
			EmploymentStatusCode = "GB",
			StudentStatusCode = "P",
			YesNoConditionOrResponseCode2 = "I",
			DateTimePeriodFormatQualifier = "Xc",
			DateTimePeriod = "i",
			ConfidentialityCode = "o",
			CityName = "Xy",
			StateOrProvinceCode = "r7",
			CountryCode = "BH",
			Number = 8,
		};

		var actual = Map.MapObject<INS_InsuredBenefit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.IndividualRelationshipCode = "FL";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Xc";
			subject.DateTimePeriod = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FL", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "V";
		//Test Parameters
		subject.IndividualRelationshipCode = individualRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Xc";
			subject.DateTimePeriod = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xc", "i", true)]
	[InlineData("Xc", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "V";
		subject.IndividualRelationshipCode = "FL";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
