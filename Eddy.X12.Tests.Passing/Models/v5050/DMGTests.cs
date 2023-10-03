using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5050.Composites;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class DMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMG*m5*2*t*1**H*3V*R*5*z*f*0t";

		var expected = new DMG_DemographicInformation()
		{
			DateTimePeriodFormatQualifier = "m5",
			DateTimePeriod = "2",
			GenderCode = "t",
			MaritalStatusCode = "1",
			CompositeRaceOrEthnicityInformation = null,
			CitizenshipStatusCode = "H",
			CountryCode = "3V",
			BasisOfVerificationCode = "R",
			Quantity = 5,
			CodeListQualifierCode = "z",
			IndustryCode = "f",
			CountryCode2 = "0t",
		};

		var actual = Map.MapObject<DMG_DemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m5", "2", true)]
	[InlineData("m5", "", false)]
	[InlineData("", "2", false)]
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
			subject.CodeListQualifierCode = "z";
			subject.IndustryCode = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "f", true)]
	[InlineData("z", "", false)]
	[InlineData("", "f", false)]
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
			subject.DateTimePeriodFormatQualifier = "m5";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "A", true)]
	[InlineData("f", "", false)]
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
			subject.DateTimePeriodFormatQualifier = "m5";
			subject.DateTimePeriod = "2";
		}
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "z";
			subject.IndustryCode = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
