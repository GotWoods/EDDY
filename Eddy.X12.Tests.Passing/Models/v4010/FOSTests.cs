using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class FOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOS*U*7*Mz*6*W*7*7";

		var expected = new FOS_FieldOfStudy()
		{
			AcademicFieldOfStudyLevelOrTypeCode = "U",
			IdentificationCodeQualifier = "7",
			IdentificationCode = "Mz",
			Description = "6",
			Description2 = "W",
			Quantity = 7,
			Quantity2 = 7,
		};

		var actual = Map.MapObject<FOS_FieldOfStudy>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredAcademicFieldOfStudyLevelOrTypeCode(string academicFieldOfStudyLevelOrTypeCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		//Test Parameters
		subject.AcademicFieldOfStudyLevelOrTypeCode = academicFieldOfStudyLevelOrTypeCode;
		//At Least one
		subject.IdentificationCodeQualifier = "7";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "7";
			subject.IdentificationCode = "Mz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "Mz", true)]
	[InlineData("7", "", false)]
	[InlineData("", "Mz", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "U";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
        subject.Description = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("7", "6", true)]
	[InlineData("7", "", true)]
	[InlineData("", "6", true)]
	public void Validation_AtLeastOneIdentificationCodeQualifier(string identificationCodeQualifier, string description, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		//Required fields
		subject.AcademicFieldOfStudyLevelOrTypeCode = "U";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.Description = description;

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
