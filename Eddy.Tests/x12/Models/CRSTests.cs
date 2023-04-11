using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*c*Y*9*6*R*v*D*3*v*w*WT*9*Va*r*C*Y*1*3*Q8kOkSHx*x1";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditOrAwardOfCredentialCode = "c",
			AcademicCreditTypeCode = "Y",
			Quantity = 9,
			Quantity2 = 6,
			AcademicGradeQualifier = "R",
			AcademicGrade = "v",
			YesNoConditionOrResponseCode = "D",
			AcademicGradeOrCourseLevelCode = "3",
			CourseRepeatOrNoCountIndicatorCode = "v",
			IdentificationCodeQualifier = "w",
			IdentificationCode = "WT",
			Quantity3 = 9,
			LevelOfIndividualTestOrCourseCode = "Va",
			Name = "r",
			ReferenceIdentification = "C",
			Name2 = "Y",
			Quantity4 = 1,
			Quantity5 = 3,
			Date = "Q8kOkSHx",
			OverrideAcademicCourseSourceCode = "x1",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validatation_RequiredBasisForAcademicCreditOrAwardOfCredentialCode(string basisForAcademicCreditOrAwardOfCredentialCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = basisForAcademicCreditOrAwardOfCredentialCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "R", true)]
	[InlineData("v", "", false)]
	public void Validation_ARequiresBAcademicGrade(string academicGrade, string academicGradeQualifier, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = "c";
		subject.AcademicGrade = academicGrade;
		subject.AcademicGradeQualifier = academicGradeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("w", "WT", true)]
	[InlineData("", "WT", false)]
	[InlineData("w", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = "c";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
