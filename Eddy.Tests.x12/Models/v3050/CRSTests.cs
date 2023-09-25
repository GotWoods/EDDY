using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*9*E*3*5*y*C*Z*b*d*F*vd*9*H6*p*m*K*8*6*jCRWsw*JJ";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditCode = "9",
			AcademicCreditTypeCode = "E",
			Quantity = 3,
			Quantity2 = 5,
			AcademicGradeQualifier = "y",
			AcademicGrade = "C",
			YesNoConditionOrResponseCode = "Z",
			AcademicGradeOrCourseLevelCode = "b",
			CourseRepeatOrNoCountIndicatorCode = "d",
			IdentificationCodeQualifier = "F",
			IdentificationCode = "vd",
			Quantity3 = 9,
			LevelOfIndividualOrTestCode = "H6",
			Name = "p",
			ReferenceNumber = "m",
			Name2 = "K",
			Quantity4 = 8,
			Quantity5 = 6,
			Date = "jCRWsw",
			OverrideAcademicCourseSourceCode = "JJ",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredBasisForAcademicCreditCode(string basisForAcademicCreditCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		//Test Parameters
		subject.BasisForAcademicCreditCode = basisForAcademicCreditCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGrade))
		{
			subject.AcademicGradeQualifier = "y";
			subject.AcademicGrade = "C";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "F";
			subject.IdentificationCode = "vd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "C", true)]
	[InlineData("y", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredAcademicGradeQualifier(string academicGradeQualifier, string academicGrade, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "9";
		//Test Parameters
		subject.AcademicGradeQualifier = academicGradeQualifier;
		subject.AcademicGrade = academicGrade;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "F";
			subject.IdentificationCode = "vd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "vd", true)]
	[InlineData("F", "", false)]
	[InlineData("", "vd", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "9";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGradeQualifier) || !string.IsNullOrEmpty(subject.AcademicGrade))
		{
			subject.AcademicGradeQualifier = "y";
			subject.AcademicGrade = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
