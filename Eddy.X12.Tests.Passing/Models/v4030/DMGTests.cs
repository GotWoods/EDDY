using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030.Composites;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class DMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMG*1X*U*e*x**b*n8*o*3*M*A";

		var expected = new DMG_DemographicInformation()
		{
			DateTimePeriodFormatQualifier = "1X",
			DateTimePeriod = "U",
			GenderCode = "e",
			MaritalStatusCode = "x",
			CompositeRaceOrEthnicityInformation = null,
			CitizenshipStatusCode = "b",
			CountryCode = "n8",
			BasisOfVerificationCode = "o",
			Quantity = 3,
			CodeListQualifierCode = "M",
			IndustryCode = "A",
		};

		var actual = Map.MapObject<DMG_DemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1X", "U", true)]
	[InlineData("1X", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "M";
			subject.IndustryCode = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "A", true)]
	[InlineData("M", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//A Requires B
		if (industryCode != "")
			subject.CompositeRaceOrEthnicityInformation = new C056_CompositeRaceOrEthnicityInformation();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "1X";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "A", true)]
	[InlineData("A", "", false)]
	public void Validation_ARequiresBIndustryCode(string industryCode, string compositeRaceOrEthnicityInformation, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		//Required fields
		//Test Parameters
		subject.IndustryCode = industryCode;
		if (compositeRaceOrEthnicityInformation != "") 
			subject.CompositeRaceOrEthnicityInformation = new C056_CompositeRaceOrEthnicityInformation();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "1X";
			subject.DateTimePeriod = "U";
		}
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "M";
			subject.IndustryCode = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
