using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ENRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENR*31Y*Zs*cG*c*I*5*2*9*O*L*1*Nw*z*k*XE*0*lo*O*7*8";

		var expected = new ENR_SchoolEnrollmentInformation()
		{
			StatusReasonCode = "31Y",
			LevelOfIndividualTestOrCourseCode = "Zs",
			DateTimePeriodFormatQualifier = "cG",
			DateTimePeriod = "c",
			MajorCourseOfStudyCode = "I",
			RangeMinimum = 5,
			RangeMaximum = 2,
			AcademicGradePointAverage = 9,
			YesNoConditionOrResponseCode = "O",
			YesNoConditionOrResponseCode2 = "L",
			YesNoConditionOrResponseCode3 = "1",
			DateTimePeriodFormatQualifier2 = "Nw",
			DateTimePeriod2 = "z",
			YesNoConditionOrResponseCode4 = "k",
			DateTimePeriodFormatQualifier3 = "XE",
			DateTimePeriod3 = "0",
			DateTimePeriodFormatQualifier4 = "lo",
			DateTimePeriod4 = "O",
			YesNoConditionOrResponseCode5 = "7",
			YesNoConditionOrResponseCode6 = "8",
		};

		var actual = Map.MapObject<ENR_SchoolEnrollmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("31Y", true)]
	public void Validation_RequiredStatusReasonCode(string statusReasonCode, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		subject.StatusReasonCode = statusReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("cG", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("cG", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		subject.StatusReasonCode = "31Y";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(5, 2, true)]
	[InlineData(0, 2, false)]
	[InlineData(5, 0, false)]
	public void Validation_AllAreRequiredRangeMinimum(decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		subject.StatusReasonCode = "31Y";
		if (rangeMinimum > 0)
		subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0)
		subject.RangeMaximum = rangeMaximum;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Nw", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("Nw", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		subject.StatusReasonCode = "31Y";
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("XE", "0", true)]
	[InlineData("", "0", false)]
	[InlineData("XE", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		subject.StatusReasonCode = "31Y";
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("lo", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("lo", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		subject.StatusReasonCode = "31Y";
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
