using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class WLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WLD*g*7Q*O*aG*4*k*6*T*F*6";

		var expected = new WLD_WorkloadDetail()
		{
			IdentificationCodeQualifier = "g",
			IdentificationCode = "7Q",
			AcademicGradeOrCourseLevelCode = "O",
			LevelOfIndividualTestOrCourseCode = "aG",
			Count = 4,
			DayRotation = "k",
			Count2 = 6,
			Name = "T",
			InstructionalSettingCode = "F",
			Percent = 6,
		};

		var actual = Map.MapObject<WLD_WorkloadDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "7Q", true)]
	[InlineData("g", "", false)]
	[InlineData("", "7Q", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new WLD_WorkloadDetail();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
