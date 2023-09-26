using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMG*e8*s*e*U*A*a*tY*b*4";

		var expected = new DMG_DemographicInformation()
		{
			DateTimePeriodFormatQualifier = "e8",
			DateTimePeriod = "s",
			GenderCode = "e",
			MaritalStatusCode = "U",
			RaceOrEthnicityCode = "A",
			CitizenshipStatusCode = "a",
			CountryCode = "tY",
			BasisOfVerificationCode = "b",
			Quantity = 4,
		};

		var actual = Map.MapObject<DMG_DemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e8", "s", true)]
	[InlineData("e8", "", false)]
	[InlineData("", "s", false)]
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
