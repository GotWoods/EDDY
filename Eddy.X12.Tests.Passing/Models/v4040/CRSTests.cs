using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*9*0*4*7*Y*m*u*o*s*p*MS*1*cb*6*c*U*2*8*LTYs89j3*R4";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditOrAwardOfCredentialCode = "9",
			AcademicCreditTypeCode = "0",
			Quantity = 4,
			Quantity2 = 7,
			AcademicGradeQualifier = "Y",
			AcademicGrade = "m",
			YesNoConditionOrResponseCode = "u",
			AcademicGradeOrCourseLevelCode = "o",
			CourseRepeatOrNoCountIndicatorCode = "s",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "MS",
			Quantity3 = 1,
			LevelOfIndividualTestOrCourseCode = "cb",
			Name = "6",
			ReferenceIdentification = "c",
			Name2 = "U",
			Quantity4 = 2,
			Quantity5 = 8,
			Date = "LTYs89j3",
			OverrideAcademicCourseSourceCode = "R4",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredBasisForAcademicCreditOrAwardOfCredentialCode(string basisForAcademicCreditOrAwardOfCredentialCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		//Test Parameters
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = basisForAcademicCreditOrAwardOfCredentialCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "MS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "Y", true)]
	[InlineData("m", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBAcademicGrade(string academicGrade, string academicGradeQualifier, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = "9";
		//Test Parameters
		subject.AcademicGrade = academicGrade;
		subject.AcademicGradeQualifier = academicGradeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "MS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "MS", true)]
	[InlineData("p", "", false)]
	[InlineData("", "MS", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = "9";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
