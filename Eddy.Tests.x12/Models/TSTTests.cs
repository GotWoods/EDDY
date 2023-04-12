using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*N*e*Zt*i*4*s*VA*Y0*p*L*I*W9*G*z*F*V*a";

		var expected = new TST_TestScoreRecord()
		{
			EducationalTestOrRequirementCode = "N",
			Name = "e",
			DateTimePeriodFormatQualifier = "Zt",
			DateTimePeriod = "i",
			ReferenceIdentification = "4",
			ReferenceIdentification2 = "s",
			LevelOfIndividualTestOrCourseCode = "VA",
			LevelOfIndividualTestOrCourseCode2 = "Y0",
			DateTimePeriod2 = "p",
			TestNormTypeCode = "L",
			TestNormingPeriodCode = "I",
			LanguageCode = "W9",
			DateTimePeriod3 = "G",
			YesNoConditionOrResponseCode = "z",
			YesNoConditionOrResponseCode2 = "F",
			TestScoreInterpretationCode = "V",
			AcademicSummarySourceCode = "a",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Zt", "i", true)]
	[InlineData("", "i", false)]
	[InlineData("Zt", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		subject.EducationalTestOrRequirementCode = "N";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
