using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SES*d*1*i*3*u*n8*M*io*c*ar*u*iu*w*eLR";

		var expected = new SES_AcademicSessionHeader()
		{
			DateTimePeriod = "d",
			Count = 1,
			DateTimePeriod2 = "i",
			SessionCode = "3",
			Name = "u",
			DateTimePeriodFormatQualifier = "n8",
			DateTimePeriod3 = "M",
			DateTimePeriodFormatQualifier2 = "io",
			DateTimePeriod4 = "c",
			LevelOfIndividualTestOrCourseCode = "ar",
			IdentificationCodeQualifier = "u",
			IdentificationCode = "iu",
			Name2 = "w",
			StatusReasonCode = "eLR",
		};

		var actual = Map.MapObject<SES_AcademicSessionHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "n8";
			subject.DateTimePeriod3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier2 = "io";
			subject.DateTimePeriod4 = "c";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "u";
			subject.IdentificationCode = "iu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n8", "M", true)]
	[InlineData("n8", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		subject.DateTimePeriod = "d";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier2 = "io";
			subject.DateTimePeriod4 = "c";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "u";
			subject.IdentificationCode = "iu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("io", "c", true)]
	[InlineData("io", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		subject.DateTimePeriod = "d";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "n8";
			subject.DateTimePeriod3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "u";
			subject.IdentificationCode = "iu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "iu", true)]
	[InlineData("u", "", false)]
	[InlineData("", "iu", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		subject.DateTimePeriod = "d";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "n8";
			subject.DateTimePeriod3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier2 = "io";
			subject.DateTimePeriod4 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
