using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class FOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOS*O*v*8f*N*8";

		var expected = new FOS_FieldOfStudy()
		{
			AcademicFieldOfStudyLevelOrTypeCode = "O",
			IdentificationCodeQualifier = "v",
			IdentificationCode = "8f",
			Description = "N",
			Description2 = "8",
		};

		var actual = Map.MapObject<FOS_FieldOfStudy>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAcademicFieldOfStudyLevelOrTypeCode(string academicFieldOfStudyLevelOrTypeCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		//Test Parameters
		subject.AcademicFieldOfStudyLevelOrTypeCode = academicFieldOfStudyLevelOrTypeCode;
		//At Least one
		subject.IdentificationCodeQualifier = "v";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "v";
			subject.IdentificationCode = "8f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "8f", true)]
	[InlineData("v", "", false)]
	[InlineData("", "8f", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "O";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

        subject.Description = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("v", "N", true)]
	[InlineData("v", "", true)]
	[InlineData("", "N", true)]
	public void Validation_AtLeastOneIdentificationCodeQualifier(string identificationCodeQualifier, string description, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "O";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.Description = description;

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
