using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INS*1*W8*L8T*tM*s**T*WX*E*m*h2*a*T*sS*j4*cJ*6*w*j";

		var expected = new INS_InsuredBenefit()
		{
			YesNoConditionOrResponseCode = "1",
			IndividualRelationshipCode = "W8",
			MaintenanceTypeCode = "L8T",
			MaintenanceReasonCode = "tM",
			BenefitStatusCode = "s",
			MedicareStatusCode = "",
			ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode = "T",
			EmploymentStatusCode = "WX",
			StudentStatusCode = "E",
			YesNoConditionOrResponseCode2 = "m",
			DateTimePeriodFormatQualifier = "h2",
			DateTimePeriod = "a",
			ConfidentialityCode = "T",
			CityName = "sS",
			StateOrProvinceCode = "j4",
			CountryCode = "cJ",
			Number = 6,
			ChangedIdentifyingInformationCode = "w",
			ProviderNetworkStatusInformationCode = "j",
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
		subject.IndividualRelationshipCode = "W8";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W8", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		subject.YesNoConditionOrResponseCode = "1";
		subject.IndividualRelationshipCode = individualRelationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("h2", "a", true)]
	[InlineData("", "a", false)]
	[InlineData("h2", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		subject.YesNoConditionOrResponseCode = "1";
		subject.IndividualRelationshipCode = "W8";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
