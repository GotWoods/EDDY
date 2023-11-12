using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Tests.Models.v4030.Composites;

public class C022Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "X*I*V3*S*9*2*4*0*6";

		var expected = new C022_HealthCareCodeInformation()
		{
			CodeListQualifierCode = "X",
			IndustryCode = "I",
			DateTimePeriodFormatQualifier = "V3",
			DateTimePeriod = "S",
			MonetaryAmount = 9,
			Quantity = 2,
			VersionIdentifier = "4",
			IndustryCode2 = "0",
			YesNoConditionOrResponseCode = "6",
		};

		var actual = Map.MapObject<C022_HealthCareCodeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.IndustryCode = "I";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "V3";
			subject.DateTimePeriod = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "X";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "V3";
			subject.DateTimePeriod = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V3", "S", true)]
	[InlineData("V3", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "X";
		subject.IndustryCode = "I";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "6", false)]
	[InlineData("0", "", true)]
	[InlineData("", "6", true)]
	public void Validation_OnlyOneOfIndustryCode2(string industryCode2, string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "X";
		subject.IndustryCode = "I";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "V3";
			subject.DateTimePeriod = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
