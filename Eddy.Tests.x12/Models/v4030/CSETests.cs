using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSE*8*t*n*2*3*d*E*J*1e*3*b*K";

		var expected = new CSE_EducationalCourseInformation()
		{
			Name = "8",
			ReferenceIdentification = "t",
			AcademicCreditTypeCode = "n",
			Quantity = 2,
			Quantity2 = 3,
			YesNoConditionOrResponseCode = "d",
			AcademicGradeOrCourseLevelCode = "E",
			IdentificationCodeQualifier = "J",
			IdentificationCode = "1e",
			EntityTitle = "3",
			YesNoConditionOrResponseCode2 = "b",
			YesNoConditionOrResponseCode3 = "K",
		};

		var actual = Map.MapObject<CSE_EducationalCourseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("8", "t", true)]
	[InlineData("8", "", true)]
	[InlineData("", "t", true)]
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
			subject.IdentificationCodeQualifier = "J";
			subject.IdentificationCode = "1e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "1e", true)]
	[InlineData("J", "", false)]
	[InlineData("", "1e", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CSE_EducationalCourseInformation();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.Name = "8";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
