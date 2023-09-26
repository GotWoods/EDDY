using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class DMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMG*TH*c*Y*z*y*D*NL";

		var expected = new DMG_DemographicInformation()
		{
			DateTimePeriodFormatQualifier = "TH",
			DateTimePeriod = "c",
			GenderCode = "Y",
			MaritalStatusCode = "z",
			RaceOrEthnicityCode = "y",
			CitizenshipStatusCode = "D",
			CountryCode = "NL",
		};

		var actual = Map.MapObject<DMG_DemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TH", "c", true)]
	[InlineData("TH", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DMG_DemographicInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
