using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*Y*5*b4*Z*J*F*t4*9e*W*D*1*Ee*W*B*c*X*1";

		var expected = new TST_TestScoreRecord()
		{
			EducationalTestOrRequirementCode = "Y",
			Name = "5",
			DateTimePeriodFormatQualifier = "b4",
			DateTimePeriod = "Z",
			ReferenceIdentification = "J",
			ReferenceIdentification2 = "F",
			LevelOfIndividualTestOrCourseCode = "t4",
			LevelOfIndividualTestOrCourseCode2 = "9e",
			DateTimePeriod2 = "W",
			TestNormTypeCode = "D",
			TestNormingPeriodCode = "1",
			LanguageCode = "Ee",
			DateTimePeriod3 = "W",
			YesNoConditionOrResponseCode = "B",
			YesNoConditionOrResponseCode2 = "c",
			TestScoreInterpretationCode = "X",
			AcademicSummarySource = "1",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "b4";
			subject.DateTimePeriod = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b4", "Z", true)]
	[InlineData("b4", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		subject.EducationalTestOrRequirementCode = "Y";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
