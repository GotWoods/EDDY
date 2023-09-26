using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class IMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMM*G*JJ*T*1*1r*o";

		var expected = new IMM_ImmunizationStatusCode()
		{
			IndustryCode = "G",
			DateTimePeriodFormatQualifier = "JJ",
			DateTimePeriod = "T",
			ImmunizationStatusCode = "1",
			ReportTypeCode = "1r",
			CodeListQualifierCode = "o",
		};

		var actual = Map.MapObject<IMM_ImmunizationStatusCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.CodeListQualifierCode = "o";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "JJ";
			subject.DateTimePeriod = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JJ", "T", true)]
	[InlineData("JJ", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.IndustryCode = "G";
		subject.CodeListQualifierCode = "o";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//A Requires B
		if (dateTimePeriod != "")
			subject.ImmunizationStatusCode = "1";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "1", true)]
	[InlineData("T", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string immunizationStatusCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.IndustryCode = "G";
		subject.CodeListQualifierCode = "o";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.ImmunizationStatusCode = immunizationStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "JJ";
			subject.DateTimePeriod = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.IndustryCode = "G";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "JJ";
			subject.DateTimePeriod = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
