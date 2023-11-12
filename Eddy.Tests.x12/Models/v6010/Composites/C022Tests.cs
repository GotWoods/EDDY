using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010;
using Eddy.x12.Models.v6010.Composites;

namespace Eddy.x12.Tests.Models.v6010.Composites;

public class C022Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "g*M*iW*9*8*7*B*H*Q";

		var expected = new C022_HealthCareCodeInformation()
		{
			CodeListQualifierCode = "g",
			IndustryCode = "M",
			DateTimePeriodFormatQualifier = "iW",
			DateTimePeriod = "9",
			MonetaryAmount = 8,
			Quantity = 7,
			VersionIdentifier = "B",
			IndustryCode2 = "H",
			IndustryCode3 = "Q",
		};

		var actual = Map.MapObject<C022_HealthCareCodeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.IndustryCode = "M";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "iW";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "g";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "iW";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iW", "9", true)]
	[InlineData("iW", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "g";
		subject.IndustryCode = "M";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "Q", false)]
	[InlineData("H", "", true)]
	[InlineData("", "Q", true)]
	public void Validation_OnlyOneOfIndustryCode2(string industryCode2, string industryCode3, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "g";
		subject.IndustryCode = "M";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.IndustryCode3 = industryCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "iW";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
