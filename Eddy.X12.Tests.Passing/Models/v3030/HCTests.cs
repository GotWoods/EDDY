using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class HCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HC*2JQ*E5lG7*6N*r*l";

		var expected = new HC_HealthCondition()
		{
			DiseaseConditionTypeCode = "2JQ",
			MedicalTreatmentTypeCode = "E5lG7",
			DateTimePeriodFormatQualifier = "6N",
			DateTimePeriod = "r",
			YesNoConditionOrResponseCode = "l",
		};

		var actual = Map.MapObject<HC_HealthCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2JQ", true)]
	public void Validation_RequiredDiseaseConditionTypeCode(string diseaseConditionTypeCode, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		//Required fields
		//Test Parameters
		subject.DiseaseConditionTypeCode = diseaseConditionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "6N";
			subject.DateTimePeriod = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6N", "r", true)]
	[InlineData("6N", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		//Required fields
		subject.DiseaseConditionTypeCode = "2JQ";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
