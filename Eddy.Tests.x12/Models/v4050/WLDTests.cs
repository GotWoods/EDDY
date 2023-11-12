using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class WLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WLD*N*m5*J*p0*2*5*1*m*X*7";

		var expected = new WLD_WorkloadDetail()
		{
			IdentificationCodeQualifier = "N",
			IdentificationCode = "m5",
			AcademicGradeOrCourseLevelCode = "J",
			LevelOfIndividualTestOrCourseCode = "p0",
			Count = 2,
			DayRotation = "5",
			Count2 = 1,
			Name = "m",
			InstructionalSettingCode = "X",
			PercentageAsDecimal = 7,
		};

		var actual = Map.MapObject<WLD_WorkloadDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "m5", true)]
	[InlineData("N", "", false)]
	[InlineData("", "m5", false)]
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
