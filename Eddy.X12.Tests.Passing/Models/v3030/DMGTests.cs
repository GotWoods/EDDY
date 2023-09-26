using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMG*VQ*O*8*S*3*0*59";

		var expected = new DMG_DemographicInformation()
		{
			DateTimePeriodFormatQualifier = "VQ",
			DateTimePeriod = "O",
			GenderCode = "8",
			MaritalStatusCode = "S",
			RaceOrEthnicityCode = "3",
			CitizenshipStatusCode = "0",
			CountryCode = "59",
		};

		var actual = Map.MapObject<DMG_DemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VQ", "O", true)]
	[InlineData("VQ", "", false)]
	[InlineData("", "O", false)]
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
