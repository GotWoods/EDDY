using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*k*5*BG*K*6*v*eB*cR*u*D*Y*Pj*z*C*b*D*Q";

		var expected = new TST_TestScoreRecord()
		{
			EducationalTestOrRequirementCode = "k",
			Name = "5",
			DateTimePeriodFormatQualifier = "BG",
			DateTimePeriod = "K",
			ReferenceIdentification = "6",
			ReferenceIdentification2 = "v",
			LevelOfIndividualTestOrCourseCode = "eB",
			LevelOfIndividualTestOrCourseCode2 = "cR",
			DateTimePeriod2 = "u",
			TestNormTypeCode = "D",
			TestNormingPeriodCode = "Y",
			LanguageCode = "Pj",
			DateTimePeriod3 = "z",
			YesNoConditionOrResponseCode = "C",
			YesNoConditionOrResponseCode2 = "b",
			TestScoreInterpretationCode = "D",
			AcademicSummarySourceCode = "Q",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "BG";
			subject.DateTimePeriod = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BG", "K", true)]
	[InlineData("BG", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		subject.EducationalTestOrRequirementCode = "k";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
