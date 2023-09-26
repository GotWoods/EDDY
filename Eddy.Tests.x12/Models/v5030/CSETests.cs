using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSE*G*l*Z*4*8*7*m*L*gh*j*l*3";

		var expected = new CSE_EducationalCourseInformation()
		{
			Name = "G",
			ReferenceIdentification = "l",
			AcademicCreditTypeCode = "Z",
			Quantity = 4,
			Quantity2 = 8,
			YesNoConditionOrResponseCode = "7",
			AcademicGradeOrCourseLevelCode = "m",
			IdentificationCodeQualifier = "L",
			IdentificationCode = "gh",
			EntityTitle = "j",
			YesNoConditionOrResponseCode2 = "l",
			YesNoConditionOrResponseCode3 = "3",
		};

		var actual = Map.MapObject<CSE_EducationalCourseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("G", "l", true)]
	[InlineData("G", "", true)]
	[InlineData("", "l", true)]
	public void Validation_AtLeastOneName(string name, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		//Required fields
		//Test Parameters
		subject.Name = name;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "L";
			subject.IdentificationCode = "gh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "gh", true)]
	[InlineData("L", "", false)]
	[InlineData("", "gh", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.Name = "G";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
