using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*i*J*4*3*4*h*Q*G*N*s*Vl*5*cI*A*y*J*6*5*JPpLh5ui*XX";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditCode = "i",
			AcademicCreditTypeCode = "J",
			Quantity = 4,
			Quantity2 = 3,
			AcademicGradeQualifier = "4",
			AcademicGrade = "h",
			YesNoConditionOrResponseCode = "Q",
			AcademicGradeOrCourseLevelCode = "G",
			CourseRepeatOrNoCountIndicatorCode = "N",
			IdentificationCodeQualifier = "s",
			IdentificationCode = "Vl",
			Quantity3 = 5,
			LevelOfIndividualTestOrCourseCode = "cI",
			Name = "A",
			ReferenceIdentification = "y",
			Name2 = "J",
			Quantity4 = 6,
			Quantity5 = 5,
			Date = "JPpLh5ui",
			OverrideAcademicCourseSourceCode = "XX",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredBasisForAcademicCreditCode(string basisForAcademicCreditCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		//Test Parameters
		subject.BasisForAcademicCreditCode = basisForAcademicCreditCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "s";
			subject.IdentificationCode = "Vl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "4", true)]
	[InlineData("h", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBAcademicGrade(string academicGrade, string academicGradeQualifier, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "i";
		//Test Parameters
		subject.AcademicGrade = academicGrade;
		subject.AcademicGradeQualifier = academicGradeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "s";
			subject.IdentificationCode = "Vl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "Vl", true)]
	[InlineData("s", "", false)]
	[InlineData("", "Vl", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "i";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
