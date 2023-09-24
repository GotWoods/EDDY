using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HC*u*F*eF*o*V*D*g";

		var expected = new HC_HealthCondition()
		{
			IndustryCode = "u",
			IndustryCode2 = "F",
			DateTimePeriodFormatQualifier = "eF",
			DateTimePeriod = "o",
			YesNoConditionOrResponseCode = "V",
			CodeListQualifierCode = "D",
			CodeListQualifierCode2 = "g",
		};

		var actual = Map.MapObject<HC_HealthCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		subject.CodeListQualifierCode = "D";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("F", "g", true)]
	[InlineData("", "g", false)]
	[InlineData("F", "", false)]
	public void Validation_AllAreRequiredIndustryCode2(string industryCode2, string codeListQualifierCode2, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		subject.IndustryCode = "u";
		subject.CodeListQualifierCode = "D";
		subject.IndustryCode2 = industryCode2;
		subject.CodeListQualifierCode2 = codeListQualifierCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("eF", "o", true)]
	[InlineData("", "o", false)]
	[InlineData("eF", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		subject.IndustryCode = "u";
		subject.CodeListQualifierCode = "D";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		subject.IndustryCode = "u";
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
