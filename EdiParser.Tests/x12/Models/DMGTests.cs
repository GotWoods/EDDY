using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

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
			CompositeRaceOrEthnicityInformation = "",
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

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "", true)]
	[InlineData("p", "", false)]
	public void Validation_ARequiresBIndustryCode(string industryCode, C056_CompositeRaceOrEthnicityInformation compositeRaceOrEthnicityInformation, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		subject.IndustryCode = industryCode;
		subject.CompositeRaceOrEthnicityInformation = compositeRaceOrEthnicityInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
