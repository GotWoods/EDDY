using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*q*f*4*4*8*2*P*R*x*s*al*lO*WI*z*O*f*5*2*a6pwdM*Zp";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditCode = "q",
			AcademicCreditTypeCode = "f",
			Quantity = 4,
			Quantity2 = 4,
			AcademicGradeQualifier = "8",
			AcademicGrade = "2",
			YesNoConditionOrResponseCode = "P",
			AcademicGradeOrCourseLevelCode = "R",
			CourseRepeatOrNoCountIndicatorCode = "x",
			IdentificationCodeQualifier = "s",
			IdentificationCode = "al",
			AcademicQualityPoints = "lO",
			LevelOfStudentOrTestCode = "WI",
			Name = "z",
			ReferenceNumber = "O",
			Name2 = "f",
			NumberOfDays = 5,
			NumberOfDays2 = 2,
			Date = "a6pwdM",
			OverrideAcademicCourseSourceCode = "Zp",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredBasisForAcademicCreditCode(string basisForAcademicCreditCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		//Test Parameters
		subject.BasisForAcademicCreditCode = basisForAcademicCreditCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGrade))
		{
			subject.AcademicGradeQualifier = "8";
			subject.AcademicGrade = "2";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "s";
			subject.IdentificationCode = "al";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "2", true)]
	[InlineData("8", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredAcademicGradeQualifier(string academicGradeQualifier, string academicGrade, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "q";
		//Test Parameters
		subject.AcademicGradeQualifier = academicGradeQualifier;
		subject.AcademicGrade = academicGrade;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "s";
			subject.IdentificationCode = "al";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "al", true)]
	[InlineData("s", "", false)]
	[InlineData("", "al", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "q";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGrade))
		{
			subject.AcademicGradeQualifier = "8";
			subject.AcademicGrade = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
