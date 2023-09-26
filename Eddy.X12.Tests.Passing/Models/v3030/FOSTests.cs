using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOS*s*w*YH*l*n";

		var expected = new FOS_FieldOfStudy()
		{
			AcademicFieldOfStudyLevelOrTypeCode = "s",
			IdentificationCodeQualifier = "w",
			IdentificationCode = "YH",
			FreeFormMessage = "l",
			FreeFormMessage2 = "n",
		};

		var actual = Map.MapObject<FOS_FieldOfStudy>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredAcademicFieldOfStudyLevelOrTypeCode(string academicFieldOfStudyLevelOrTypeCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.IdentificationCodeQualifier = "w";
		subject.IdentificationCode = "YH";
		//Test Parameters
		subject.AcademicFieldOfStudyLevelOrTypeCode = academicFieldOfStudyLevelOrTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "s";
		subject.IdentificationCode = "YH";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YH", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "s";
		subject.IdentificationCodeQualifier = "w";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
