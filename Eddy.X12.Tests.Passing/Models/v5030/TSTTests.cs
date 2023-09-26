using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*S*4*YP*K*B*F*jW*RN*u*7*8*3P*D*Q*v*Z*v";

		var expected = new TST_TestScoreRecord()
		{
			EducationalTestOrRequirementCode = "S",
			Name = "4",
			DateTimePeriodFormatQualifier = "YP",
			DateTimePeriod = "K",
			ReferenceIdentification = "B",
			ReferenceIdentification2 = "F",
			LevelOfIndividualTestOrCourseCode = "jW",
			LevelOfIndividualTestOrCourseCode2 = "RN",
			DateTimePeriod2 = "u",
			TestNormTypeCode = "7",
			TestNormingPeriodCode = "8",
			LanguageCode = "3P",
			DateTimePeriod3 = "D",
			YesNoConditionOrResponseCode = "Q",
			YesNoConditionOrResponseCode2 = "v",
			TestScoreInterpretationCode = "Z",
			AcademicSummarySource = "v",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "YP";
			subject.DateTimePeriod = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YP", "K", true)]
	[InlineData("YP", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		subject.EducationalTestOrRequirementCode = "S";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
