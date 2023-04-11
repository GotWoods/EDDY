using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SES*J*3*r*y*h*41*X*9p*F*3v*f*FE*5*8Xp";

		var expected = new SES_AcademicSessionHeader()
		{
			DateTimePeriod = "J",
			Count = 3,
			DateTimePeriod2 = "r",
			SessionCode = "y",
			Name = "h",
			DateTimePeriodFormatQualifier = "41",
			DateTimePeriod3 = "X",
			DateTimePeriodFormatQualifier2 = "9p",
			DateTimePeriod4 = "F",
			LevelOfIndividualTestOrCourseCode = "3v",
			IdentificationCodeQualifier = "f",
			IdentificationCode = "FE",
			Name2 = "5",
			StatusReasonCode = "8Xp",
		};

		var actual = Map.MapObject<SES_AcademicSessionHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("41", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("41", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		subject.DateTimePeriod = "J";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod3 = dateTimePeriod3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("9p", "F", true)]
	[InlineData("", "F", false)]
	[InlineData("9p", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		subject.DateTimePeriod = "J";
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod4 = dateTimePeriod4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("f", "FE", true)]
	[InlineData("", "FE", false)]
	[InlineData("f", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		subject.DateTimePeriod = "J";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
