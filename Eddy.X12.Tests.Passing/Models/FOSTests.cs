using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOS*T*a*Yo*0*h*8*1";

		var expected = new FOS_FieldOfStudy()
		{
			AcademicFieldOfStudyLevelOrTypeCode = "T",
			IdentificationCodeQualifier = "a",
			IdentificationCode = "Yo",
			Description = "0",
			Description2 = "h",
			Quantity = 8,
			Quantity2 = 1,
		};

		var actual = Map.MapObject<FOS_FieldOfStudy>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredAcademicFieldOfStudyLevelOrTypeCode(string academicFieldOfStudyLevelOrTypeCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		subject.AcademicFieldOfStudyLevelOrTypeCode = academicFieldOfStudyLevelOrTypeCode;
        subject.Description = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("a", "Yo", true)]
	[InlineData("", "Yo", false)]
	[InlineData("a", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		subject.AcademicFieldOfStudyLevelOrTypeCode = "T";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		subject.Description = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("a","0", true)]
	[InlineData("", "0", true)]
	[InlineData("a", "", true)]
	public void Validation_AtLeastOneIdentificationCodeQualifier(string identificationCodeQualifier, string description, bool isValidExpected)
	{
		var subject = new FOS_FieldOfStudy();
		subject.AcademicFieldOfStudyLevelOrTypeCode = "T";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.Description = description;

		if (identificationCodeQualifier != "")
			subject.IdentificationCode = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
