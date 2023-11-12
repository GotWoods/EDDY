using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class INSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INS*i*mL*7sR*xP*L**w*Qf*W*6*5A*j*9*0t*xt*nn*1*y*3*h*5*W*W*9*I*M*r*G*E*W";

		var expected = new INS_InsuredBenefit()
		{
			YesNoConditionOrResponseCode = "i",
			IndividualRelationshipCode = "mL",
			MaintenanceTypeCode = "7sR",
			MaintenanceReasonCode = "xP",
			BenefitStatusCode = "L",
			MedicareStatusCode = null,
			ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode = "w",
			EmploymentStatusCode = "Qf",
			StudentStatusCode = "W",
			YesNoConditionOrResponseCode2 = "6",
			DateTimePeriodFormatQualifier = "5A",
			DateTimePeriod = "j",
			ConfidentialityCode = "9",
			CityName = "0t",
			StateOrProvinceCode = "xt",
			CountryCode = "nn",
			Number = 1,
			YesNoConditionOrResponseCode3 = "y",
			YesNoConditionOrResponseCode4 = "3",
			YesNoConditionOrResponseCode5 = "h",
			YesNoConditionOrResponseCode6 = "5",
			YesNoConditionOrResponseCode7 = "W",
			YesNoConditionOrResponseCode8 = "W",
			YesNoConditionOrResponseCode9 = "9",
			YesNoConditionOrResponseCode10 = "I",
			YesNoConditionOrResponseCode11 = "M",
			YesNoConditionOrResponseCode12 = "r",
			YesNoConditionOrResponseCode13 = "G",
			YesNoConditionOrResponseCode14 = "E",
			YesNoConditionOrResponseCode15 = "W",
		};

		var actual = Map.MapObject<INS_InsuredBenefit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.IndividualRelationshipCode = "mL";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "5A";
			subject.DateTimePeriod = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mL", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		//Test Parameters
		subject.IndividualRelationshipCode = individualRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "5A";
			subject.DateTimePeriod = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5A", "j", true)]
	[InlineData("5A", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INS_InsuredBenefit();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		subject.IndividualRelationshipCode = "mL";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
