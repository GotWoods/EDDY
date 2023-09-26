using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class INSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INS*1*PI*Tyb*t6*b*U*Z*Cj*M*y*sh*2*T*if*pN*OD";

		var expected = new INS_InsuredBenefit()
		{
			YesNoConditionOrResponseCode = "1",
			IndividualRelationshipCode = "PI",
			MaintenanceTypeCode = "Tyb",
			MaintenanceReasonCode = "t6",
			BenefitStatusCode = "b",
			MedicarePlanCode = "U",
			ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode = "Z",
			EmploymentStatusCode = "Cj",
			StudentStatusCode = "M",
			YesNoConditionOrResponseCode2 = "y",
			DateTimePeriodFormatQualifier = "sh",
			DateTimePeriod = "2",
			ConfidentialityCode = "T",
			CityName = "if",
			StateOrProvinceCode = "pN",
			CountryCode = "OD",
		};

		var actual = Map.MapObject<INS_InsuredBenefit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.IndividualRelationshipCode = "PI";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sh";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PI", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "1";
		//Test Parameters
		subject.IndividualRelationshipCode = individualRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sh";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sh", "2", true)]
	[InlineData("sh", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "1";
		subject.IndividualRelationshipCode = "PI";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
