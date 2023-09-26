using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSE*a*Y*9*1*9*P*r*U*R1*h*H*L";

		var expected = new CSE_EducationalCourseInformation()
		{
			Name = "a",
			ReferenceIdentification = "Y",
			AcademicCreditTypeCode = "9",
			Quantity = 1,
			Quantity2 = 9,
			YesNoConditionOrResponseCode = "P",
			AcademicGradeOrCourseLevelCode = "r",
			IdentificationCodeQualifier = "U",
			IdentificationCode = "R1",
			EntityTitle = "h",
			YesNoConditionOrResponseCode2 = "H",
			YesNoConditionOrResponseCode3 = "L",
		};

		var actual = Map.MapObject<CSE_EducationalCourseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("a", "Y", true)]
	[InlineData("a", "", true)]
	[InlineData("", "Y", true)]
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
			subject.IdentificationCodeQualifier = "U";
			subject.IdentificationCode = "R1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "R1", true)]
	[InlineData("U", "", false)]
	[InlineData("", "R1", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.Name = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
