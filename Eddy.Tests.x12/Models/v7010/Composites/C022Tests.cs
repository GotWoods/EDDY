using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7010;
using Eddy.x12.Models.v7010.Composites;

namespace Eddy.x12.Tests.Models.v7010.Composites;

public class C022Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "8*O*WG*9*8*9*O*1*l*k";

		var expected = new C022_HealthCareCodeInformation()
		{
			CodeListQualifierCode = "8",
			IndustryCode = "O",
			DateTimePeriodFormatQualifier = "WG",
			DateTimePeriod = "9",
			MonetaryAmount = 8,
			Quantity = 9,
			VersionIdentifier = "O",
			IndustryCode2 = "1",
			IndustryCode3 = "l",
			IndustryCode4 = "k",
		};

		var actual = Map.MapObject<C022_HealthCareCodeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.IndustryCode = "O";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "WG";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "8";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "WG";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WG", "9", true)]
	[InlineData("WG", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "8";
		subject.IndustryCode = "O";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "l", false)]
	[InlineData("1", "", true)]
	[InlineData("", "l", true)]
	public void Validation_OnlyOneOfIndustryCode2(string industryCode2, string industryCode3, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "8";
		subject.IndustryCode = "O";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.IndustryCode3 = industryCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "WG";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
