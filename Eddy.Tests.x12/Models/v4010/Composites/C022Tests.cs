using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;
using Eddy.x12.Models.v4010.Composites;

namespace Eddy.x12.Tests.Models.v4010.Composites;

public class C022Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "G*5*ls*x*1*6*i";

		var expected = new C022_HealthCareCodeInformation()
		{
			CodeListQualifierCode = "G",
			IndustryCode = "5",
			DateTimePeriodFormatQualifier = "ls",
			DateTimePeriod = "x",
			MonetaryAmount = 1,
			Quantity = 6,
			VersionIdentifier = "i",
		};

		var actual = Map.MapObject<C022_HealthCareCodeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.IndustryCode = "5";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ls";
			subject.DateTimePeriod = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "G";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ls";
			subject.DateTimePeriod = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ls", "x", true)]
	[InlineData("ls", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new C022_HealthCareCodeInformation();
		//Required fields
		subject.CodeListQualifierCode = "G";
		subject.IndustryCode = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
