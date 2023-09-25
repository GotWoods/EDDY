using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRS*S*R*7*4*r*V*b*7*T*6*3J*3*4P*v*p*1*1*6*0UP2x6bz*1R";

		var expected = new CRS_CourseRecord()
		{
			BasisForAcademicCreditOrAwardOfCredentialCode = "S",
			AcademicCreditTypeCode = "R",
			Quantity = 7,
			Quantity2 = 4,
			AcademicGradeQualifier = "r",
			AcademicGrade = "V",
			YesNoConditionOrResponseCode = "b",
			AcademicGradeOrCourseLevelCode = "7",
			CourseRepeatOrNoCountIndicatorCode = "T",
			IdentificationCodeQualifier = "6",
			IdentificationCode = "3J",
			Quantity3 = 3,
			LevelOfIndividualTestOrCourseCode = "4P",
			Name = "v",
			ReferenceIdentification = "p",
			Name2 = "1",
			Quantity4 = 1,
			Quantity5 = 6,
			Date = "0UP2x6bz",
			OverrideAcademicCourseSourceCode = "1R",
		};

		var actual = Map.MapObject<CRS_CourseRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredBasisForAcademicCreditOrAwardOfCredentialCode(string basisForAcademicCreditOrAwardOfCredentialCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		//Test Parameters
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = basisForAcademicCreditOrAwardOfCredentialCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "6";
			subject.IdentificationCode = "3J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "r", true)]
	[InlineData("V", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBAcademicGrade(string academicGrade, string academicGradeQualifier, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = "S";
		//Test Parameters
		subject.AcademicGrade = academicGrade;
		subject.AcademicGradeQualifier = academicGradeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "6";
			subject.IdentificationCode = "3J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "3J", true)]
	[InlineData("6", "", false)]
	[InlineData("", "3J", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CRS_CourseRecord();
		//Required fields
		subject.BasisForAcademicCreditOrAwardOfCredentialCode = "S";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
