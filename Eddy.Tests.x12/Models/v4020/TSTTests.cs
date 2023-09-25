using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*Z*3*lq*5*E*C*ga*gA*1*S*L*zj*u*H*2*d";

		var expected = new TST_TestScoreRecord()
		{
			EducationalTestOrRequirementCode = "Z",
			Name = "3",
			DateTimePeriodFormatQualifier = "lq",
			DateTimePeriod = "5",
			ReferenceIdentification = "E",
			ReferenceIdentification2 = "C",
			LevelOfIndividualTestOrCourseCode = "ga",
			LevelOfIndividualTestOrCourseCode2 = "gA",
			DateTimePeriod2 = "1",
			TestNormTypeCode = "S",
			TestNormingPeriodCode = "L",
			LanguageCode = "zj",
			DateTimePeriod3 = "u",
			YesNoConditionOrResponseCode = "H",
			YesNoConditionOrResponseCode2 = "2",
			TestScoreInterpretationCode = "d",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "lq";
			subject.DateTimePeriod = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lq", "5", true)]
	[InlineData("lq", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		subject.EducationalTestOrRequirementCode = "Z";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
