using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class INSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INS*7*QZ*M1o*o3*F**W*lu*l*M*ZX*P*K*8z*jy*HD*9*r*C";

		var expected = new INS_InsuredBenefit()
		{
			YesNoConditionOrResponseCode = "7",
			IndividualRelationshipCode = "QZ",
			MaintenanceTypeCode = "M1o",
			MaintenanceReasonCode = "o3",
			BenefitStatusCode = "F",
			MedicareStatusCode = null,
			ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode = "W",
			EmploymentStatusCode = "lu",
			StudentStatusCode = "l",
			YesNoConditionOrResponseCode2 = "M",
			DateTimePeriodFormatQualifier = "ZX",
			DateTimePeriod = "P",
			ConfidentialityCode = "K",
			CityName = "8z",
			StateOrProvinceCode = "jy",
			CountryCode = "HD",
			Number = 9,
			ChangedIdentifyingInformationCode = "r",
			ProviderNetworkStatusInformationCode = "C",
		};

		var actual = Map.MapObject<INS_InsuredBenefit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.IndividualRelationshipCode = "QZ";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZX";
			subject.DateTimePeriod = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QZ", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "7";
		//Test Parameters
		subject.IndividualRelationshipCode = individualRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZX";
			subject.DateTimePeriod = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZX", "P", true)]
	[InlineData("ZX", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "7";
		subject.IndividualRelationshipCode = "QZ";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
