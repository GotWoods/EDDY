using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class HCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HC*T*M*ae*9*s*o*w";

		var expected = new HC_HealthCondition()
		{
			IndustryCode = "T",
			IndustryCode2 = "M",
			DateTimePeriodFormatQualifier = "ae",
			DateTimePeriod = "9",
			YesNoConditionOrResponseCode = "s",
			CodeListQualifierCode = "o",
			CodeListQualifierCode2 = "w",
		};

		var actual = Map.MapObject<HC_HealthCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		//Required fields
		subject.CodeListQualifierCode = "o";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IndustryCode2) || !string.IsNullOrEmpty(subject.IndustryCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2))
		{
			subject.IndustryCode2 = "M";
			subject.CodeListQualifierCode2 = "w";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ae";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "w", true)]
	[InlineData("M", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredIndustryCode2(string industryCode2, string codeListQualifierCode2, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		//Required fields
		subject.IndustryCode = "T";
		subject.CodeListQualifierCode = "o";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ae";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ae", "9", true)]
	[InlineData("ae", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		//Required fields
		subject.IndustryCode = "T";
		subject.CodeListQualifierCode = "o";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IndustryCode2) || !string.IsNullOrEmpty(subject.IndustryCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2))
		{
			subject.IndustryCode2 = "M";
			subject.CodeListQualifierCode2 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new HC_HealthCondition();
		//Required fields
		subject.IndustryCode = "T";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IndustryCode2) || !string.IsNullOrEmpty(subject.IndustryCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2))
		{
			subject.IndustryCode2 = "M";
			subject.CodeListQualifierCode2 = "w";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ae";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
