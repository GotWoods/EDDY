using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*w*j*3*3*2*H*P*p*4*O*Xo*1*9n*2*t*6*6*3*sjNhfQWu*sZ";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditCode = "w",
			AcademicCreditTypeCode = "j",
			Quantity = 3,
			Quantity2 = 3,
			AcademicGradeQualifier = "2",
			AcademicGrade = "H",
			YesNoConditionOrResponseCode = "P",
			AcademicGradeOrCourseLevelCode = "p",
			CourseRepeatOrNoCountIndicatorCode = "4",
			IdentificationCodeQualifier = "O",
			IdentificationCode = "Xo",
			Quantity3 = 1,
			LevelOfIndividualTestOrCourseCode = "9n",
			Name = "2",
			ReferenceIdentification = "t",
			Name2 = "6",
			Quantity4 = 6,
			Quantity5 = 3,
			Date = "sjNhfQWu",
			OverrideAcademicCourseSourceCode = "sZ",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredBasisForAcademicCreditCode(string basisForAcademicCreditCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		//Test Parameters
		subject.BasisForAcademicCreditCode = basisForAcademicCreditCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "O";
			subject.IdentificationCode = "Xo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "2", true)]
	[InlineData("H", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBAcademicGrade(string academicGrade, string academicGradeQualifier, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "w";
		//Test Parameters
		subject.AcademicGrade = academicGrade;
		subject.AcademicGradeQualifier = academicGradeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "O";
			subject.IdentificationCode = "Xo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "Xo", true)]
	[InlineData("O", "", false)]
	[InlineData("", "Xo", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditCode = "w";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
