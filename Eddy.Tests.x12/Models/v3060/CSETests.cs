using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSE*s*f*t*8*8*g*V*6*UA*a*T*l";

		var expected = new CSE_EducationalCourseInformation()
		{
			Name = "s",
			ReferenceIdentification = "f",
			AcademicCreditTypeCode = "t",
			Quantity = 8,
			Quantity2 = 8,
			YesNoConditionOrResponseCode = "g",
			AcademicGradeOrCourseLevelCode = "V",
			IdentificationCodeQualifier = "6",
			IdentificationCode = "UA",
			EntityTitle = "a",
			YesNoConditionOrResponseCode2 = "T",
			YesNoConditionOrResponseCode3 = "l",
		};

		var actual = Map.MapObject<CSE_EducationalCourseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("s", "f", true)]
	[InlineData("s", "", true)]
	[InlineData("", "f", true)]
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
			subject.IdentificationCodeQualifier = "6";
			subject.IdentificationCode = "UA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "UA", true)]
	[InlineData("6", "", false)]
	[InlineData("", "UA", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.Name = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
