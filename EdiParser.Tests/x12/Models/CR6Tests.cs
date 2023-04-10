using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CR6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR6*s*A8yDP4dW*EX*6*LYeoyvvR*9*a*r*mRFUDTVm*oB*v*aoV4QKl6*lveLrt5I*0JfdGVBQ*za*v*I*elrnKFu5*k6MPmy8p*yV1PQ4N7*hlKiIr0m";

		var expected = new CR6_HomeHealthCareCertification()
		{
			PrognosisCode = "s",
			Date = "A8yDP4dW",
			DateTimePeriodFormatQualifier = "EX",
			DateTimePeriod = "6",
			Date2 = "LYeoyvvR",
			YesNoConditionOrResponseCode = "9",
			YesNoConditionOrResponseCode2 = "a",
			CertificationTypeCode = "r",
			Date3 = "mRFUDTVm",
			ProductServiceIDQualifier = "oB",
			MedicalCodeValue = "v",
			Date4 = "aoV4QKl6",
			Date5 = "lveLrt5I",
			Date6 = "0JfdGVBQ",
			DateTimePeriodFormatQualifier2 = "za",
			DateTimePeriod2 = "v",
			PatientLocationCode = "I",
			Date7 = "elrnKFu5",
			Date8 = "k6MPmy8p",
			Date9 = "yV1PQ4N7",
			Date10 = "hlKiIr0m",
		};

		var actual = Map.MapObject<CR6_HomeHealthCareCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validatation_RequiredPrognosisCode(string prognosisCode, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		subject.Date = "A8yDP4dW";
		subject.PrognosisCode = prognosisCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A8yDP4dW", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		subject.PrognosisCode = "s";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("EX", "6", true)]
	[InlineData("", "6", false)]
	[InlineData("EX", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		subject.PrognosisCode = "s";
		subject.Date = "A8yDP4dW";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
