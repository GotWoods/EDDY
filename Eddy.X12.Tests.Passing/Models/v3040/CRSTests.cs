using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*s*K*4*3*9*E*0*8*U*G*4n*9*2i*G*W*p*9*6*F1cfzG*7J";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditCode = "s",
			AcademicCreditTypeCode = "K",
			Quantity = 4,
			Quantity2 = 3,
			AcademicGradeQualifier = "9",
			AcademicGrade = "E",
			YesNoConditionOrResponseCode = "0",
			AcademicGradeOrCourseLevelCode = "8",
			CourseRepeatOrNoCountIndicatorCode = "U",
			IdentificationCodeQualifier = "G",
			IdentificationCode = "4n",
			Quantity3 = 9,
			LevelOfIndividualOrTestCode = "2i",
			Name = "G",
			ReferenceNumber = "W",
			Name2 = "p",
			Quantity4 = 9,
			Quantity5 = 6,
			Date = "F1cfzG",
			OverrideAcademicCourseSourceCode = "7J",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredBasisForAcademicCreditCode(string basisForAcademicCreditCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		//Test Parameters
		subject.BasisForAcademicCreditCode = basisForAcademicCreditCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGrade))
		{
			subject.AcademicGradeQualifier = "9";
			subject.AcademicGrade = "E";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "G";
			subject.IdentificationCode = "4n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "E", true)]
	[InlineData("9", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredAcademicGradeQualifier(string academicGradeQualifier, string academicGrade, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "s";
		//Test Parameters
		subject.AcademicGradeQualifier = academicGradeQualifier;
		subject.AcademicGrade = academicGrade;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "G";
			subject.IdentificationCode = "4n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "4n", true)]
	[InlineData("G", "", false)]
	[InlineData("", "4n", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "s";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGrade))
		{
			subject.AcademicGradeQualifier = "9";
			subject.AcademicGrade = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
