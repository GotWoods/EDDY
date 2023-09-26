using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*9*9*5q*9*D*0*WP*3f*E*6*a*bv*N*X*Y";

		var expected = new TST_TestScoreRecord()
		{
			EducationalTestOrRequirementCode = "9",
			Name = "9",
			DateTimePeriodFormatQualifier = "5q",
			DateTimePeriod = "9",
			ReferenceIdentification = "D",
			ReferenceIdentification2 = "0",
			LevelOfIndividualTestOrCourseCode = "WP",
			LevelOfIndividualTestOrCourseCode2 = "3f",
			DateTimePeriod2 = "E",
			TestNormTypeCode = "6",
			TestNormingPeriodCode = "a",
			LanguageCode = "bv",
			DateTimePeriod3 = "N",
			YesNoConditionOrResponseCode = "X",
			YesNoConditionOrResponseCode2 = "Y",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "5q";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5q", "9", true)]
	[InlineData("5q", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		subject.EducationalTestOrRequirementCode = "9";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
