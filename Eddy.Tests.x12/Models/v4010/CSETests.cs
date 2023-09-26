using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSE*Z*A*o*6*3*y*q*p*bh*t*6*W";

		var expected = new CSE_EducationalCourseInformation()
		{
			Name = "Z",
			ReferenceIdentification = "A",
			AcademicCreditTypeCode = "o",
			Quantity = 6,
			Quantity2 = 3,
			YesNoConditionOrResponseCode = "y",
			AcademicGradeOrCourseLevelCode = "q",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "bh",
			EntityTitle = "t",
			YesNoConditionOrResponseCode2 = "6",
			YesNoConditionOrResponseCode3 = "W",
		};

		var actual = Map.MapObject<CSE_EducationalCourseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Z", "A", true)]
	[InlineData("Z", "", true)]
	[InlineData("", "A", true)]
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
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "bh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "bh", true)]
	[InlineData("p", "", false)]
	[InlineData("", "bh", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.Name = "Z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
