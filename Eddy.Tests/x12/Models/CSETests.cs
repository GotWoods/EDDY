using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSE*K*I*t*3*5*A*E*U*dh*M*V*l";

		var expected = new CSE_EducationalCourseInformation()
		{
			Name = "K",
			ReferenceIdentification = "I",
			AcademicCreditTypeCode = "t",
			Quantity = 3,
			Quantity2 = 5,
			YesNoConditionOrResponseCode = "A",
			AcademicGradeOrCourseLevelCode = "E",
			IdentificationCodeQualifier = "U",
			IdentificationCode = "dh",
			EntityTitle = "M",
			YesNoConditionOrResponseCode2 = "V",
			YesNoConditionOrResponseCode3 = "l",
		};

		var actual = Map.MapObject<CSE_EducationalCourseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("K","I", true)]
	[InlineData("", "I", true)]
	[InlineData("K", "", true)]
	public void Validation_AtLeastOneName(string name, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		subject.Name = name;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("U", "dh", true)]
	[InlineData("", "dh", false)]
	[InlineData("U", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		subject.Name = "ABCD";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
