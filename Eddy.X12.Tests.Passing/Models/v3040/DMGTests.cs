using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMG*90*I*3*W*N*W*FF*Z";

		var expected = new DMG_DemographicInformation()
		{
			DateTimePeriodFormatQualifier = "90",
			DateTimePeriod = "I",
			GenderCode = "3",
			MaritalStatusCode = "W",
			RaceOrEthnicityCode = "N",
			CitizenshipStatusCode = "W",
			CountryCode = "FF",
			BasisOfVerificationCode = "Z",
		};

		var actual = Map.MapObject<DMG_DemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("90", "I", true)]
	[InlineData("90", "", false)]
	[InlineData("", "I", false)]
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
