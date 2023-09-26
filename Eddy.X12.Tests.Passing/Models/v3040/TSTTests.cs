using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TST*Y*L*ib*R*N*e*63*rn*o*T*u*uP";

		var expected = new TST_TestScoreRecord()
		{
			StudentTestCode = "Y",
			Name = "L",
			DateTimePeriodFormatQualifier = "ib",
			DateTimePeriod = "R",
			ReferenceNumber = "N",
			ReferenceNumber2 = "e",
			LevelOfIndividualOrTestCode = "63",
			LevelOfIndividualOrTestCode2 = "rn",
			DateTimePeriod2 = "o",
			TestNormTypeCode = "T",
			TestNormingPeriodCode = "u",
			LanguageCode = "uP",
		};

		var actual = Map.MapObject<TST_TestScoreRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredStudentTestCode(string studentTestCode, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		//Test Parameters
		subject.StudentTestCode = studentTestCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ib";
			subject.DateTimePeriod = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ib", "R", true)]
	[InlineData("ib", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TST_TestScoreRecord();
		//Required fields
		subject.StudentTestCode = "Y";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
