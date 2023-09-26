using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*1*y*9B*c*C*h*fX*hU*P*c*0*di*J";

		var expected = new TST_TestScoreRecord()
		{
			EducationalTestOrRequirementCode = "1",
			Name = "y",
			DateTimePeriodFormatQualifier = "9B",
			DateTimePeriod = "c",
			ReferenceIdentification = "C",
			ReferenceIdentification2 = "h",
			LevelOfIndividualTestOrCourseCode = "fX",
			LevelOfIndividualTestOrCourseCode2 = "hU",
			DateTimePeriod2 = "P",
			TestNormTypeCode = "c",
			TestNormingPeriodCode = "0",
			LanguageCode = "di",
			DateTimePeriod3 = "J",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "9B";
			subject.DateTimePeriod = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9B", "c", true)]
	[InlineData("9B", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		subject.EducationalTestOrRequirementCode = "1";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
