using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SES*Q*4*p*x*O*8r*g*31*R*MU*S*nq*G*bmS";

		var expected = new SES_AcademicSessionHeader()
		{
			DateTimePeriod = "Q",
			Count = 4,
			DateTimePeriod2 = "p",
			SessionCode = "x",
			Name = "O",
			DateTimePeriodFormatQualifier = "8r",
			DateTimePeriod3 = "g",
			DateTimePeriodFormatQualifier2 = "31",
			DateTimePeriod4 = "R",
			LevelOfIndividualTestOrCourseCode = "MU",
			IdentificationCodeQualifier = "S",
			IdentificationCode = "nq",
			Name2 = "G",
			StatusReasonCode = "bmS",
		};

		var actual = Map.MapObject<SES_AcademicSessionHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "8r";
			subject.DateTimePeriod3 = "g";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier2 = "31";
			subject.DateTimePeriod4 = "R";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "S";
			subject.IdentificationCode = "nq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8r", "g", true)]
	[InlineData("8r", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		subject.DateTimePeriod = "Q";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier2 = "31";
			subject.DateTimePeriod4 = "R";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "S";
			subject.IdentificationCode = "nq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("31", "R", true)]
	[InlineData("31", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		subject.DateTimePeriod = "Q";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "8r";
			subject.DateTimePeriod3 = "g";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "S";
			subject.IdentificationCode = "nq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "nq", true)]
	[InlineData("S", "", false)]
	[InlineData("", "nq", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new SES_AcademicSessionHeader();
		//Required fields
		subject.DateTimePeriod = "Q";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "8r";
			subject.DateTimePeriod3 = "g";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier2 = "31";
			subject.DateTimePeriod4 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
