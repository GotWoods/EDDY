using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class DMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMG*iV*p*Y*b**c*GK*4*6*R*p*GR";

		var expected = new DMG_DemographicInformation()
		{
			DateTimePeriodFormatQualifier = "iV",
			DateTimePeriod = "p",
			GenderCode = "Y",
			MaritalStatusCode = "b",
			CompositeRaceOrEthnicityInformation = null,
			CitizenshipStatusCode = "c",
			CountryCode = "GK",
			BasisOfVerificationCode = "4",
			Quantity = 6,
			CodeListQualifierCode = "R",
			IndustryCode = "p",
			CountryCode2 = "GR",
		};

		var actual = Map.MapObject<DMG_DemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("iV", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("iV", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("R", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("R", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		if (industryCode != "")
			subject.CompositeRaceOrEthnicityInformation = new C056_CompositeRaceOrEthnicityInformation();

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "AB", true)]
	[InlineData("p", "", false)]
	public void Validation_ARequiresBIndustryCode(string industryCode, string compositeRaceOrEthnicityInformation, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		subject.IndustryCode = industryCode;
		if (industryCode != "")
			subject.CodeListQualifierCode = "A";
		if (compositeRaceOrEthnicityInformation != "")
		    subject.CompositeRaceOrEthnicityInformation = new C056_CompositeRaceOrEthnicityInformation() { RaceOrEthnicityCode = compositeRaceOrEthnicityInformation };

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}