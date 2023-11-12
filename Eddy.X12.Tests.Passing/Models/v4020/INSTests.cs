using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class INSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INS*d*Vj*RGD*Bw*S**q*cf*k*T*aP*F*Y*nt*Yb*2Q*4";

		var expected = new INS_InsuredBenefit()
		{
			YesNoConditionOrResponseCode = "d",
			IndividualRelationshipCode = "Vj",
			MaintenanceTypeCode = "RGD",
			MaintenanceReasonCode = "Bw",
			BenefitStatusCode = "S",
			MedicareStatusCode = null,
			ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode = "q",
			EmploymentStatusCode = "cf",
			StudentStatusCode = "k",
			YesNoConditionOrResponseCode2 = "T",
			DateTimePeriodFormatQualifier = "aP",
			DateTimePeriod = "F",
			ConfidentialityCode = "Y",
			CityName = "nt",
			StateOrProvinceCode = "Yb",
			CountryCode = "2Q",
			Number = 4,
		};

		var actual = Map.MapObject<INS_InsuredBenefit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.IndividualRelationshipCode = "Vj";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "aP";
			subject.DateTimePeriod = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vj", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "d";
		//Test Parameters
		subject.IndividualRelationshipCode = individualRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "aP";
			subject.DateTimePeriod = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aP", "F", true)]
	[InlineData("aP", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "d";
		subject.IndividualRelationshipCode = "Vj";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
