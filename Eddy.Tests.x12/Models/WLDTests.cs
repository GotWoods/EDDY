using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class WLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WLD*m*y8*c*A0*6*b*4*z*3*2";

		var expected = new WLD_WorkloadDetail()
		{
			IdentificationCodeQualifier = "m",
			IdentificationCode = "y8",
			AcademicGradeOrCourseLevelCode = "c",
			LevelOfIndividualTestOrCourseCode = "A0",
			Count = 6,
			DayRotation = "b",
			Count2 = 4,
			Name = "z",
			InstructionalSettingCode = "3",
			PercentageAsDecimal = 2,
		};

		var actual = Map.MapObject<WLD_WorkloadDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("m", "y8", true)]
	[InlineData("", "y8", false)]
	[InlineData("m", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new WLD_WorkloadDetail();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
