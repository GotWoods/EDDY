using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class FOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOS*F*M*wu*X*i";

		var expected = new FOS_FieldOfStudy()
		{
			AcademicFieldOfStudyLevelOrTypeCode = "F",
			IdentificationCodeQualifier = "M",
			IdentificationCode = "wu",
			Description = "X",
			Description2 = "i",
		};

		var actual = Map.MapObject<FOS_FieldOfStudy>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredAcademicFieldOfStudyLevelOrTypeCode(string academicFieldOfStudyLevelOrTypeCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.IdentificationCodeQualifier = "M";
		subject.IdentificationCode = "wu";
		//Test Parameters
		subject.AcademicFieldOfStudyLevelOrTypeCode = academicFieldOfStudyLevelOrTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "F";
		subject.IdentificationCode = "wu";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wu", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "F";
		subject.IdentificationCodeQualifier = "M";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
