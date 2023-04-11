using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HS*V*rd*7*iZA*X";

		var expected = new HS_HealthScreening()
		{
			IndustryCode = "V",
			DateTimePeriodFormatQualifier = "rd",
			DateTimePeriod = "7",
			StatusReasonCode = "iZA",
			CodeListQualifierCode = "X",
		};

		var actual = Map.MapObject<HS_HealthScreening>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new HS_HealthScreening();
		subject.CodeListQualifierCode = "X";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("rd", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("rd", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new HS_HealthScreening();
		subject.IndustryCode = "V";
		subject.CodeListQualifierCode = "X";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new HS_HealthScreening();
		subject.IndustryCode = "V";
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
