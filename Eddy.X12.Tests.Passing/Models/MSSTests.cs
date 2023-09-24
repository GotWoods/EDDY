using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSS*Th*o*Rk*bb*S*3*S6U";

		var expected = new MSS_MaterialSafetyDataSheetSectionInformation()
		{
			ReportSectionNameCode = "Th",
			Description = "o",
			StateOrProvinceCode = "Rk",
			CountryCode = "bb",
			ChangeTypeCode = "S",
			ReportSectionNumber = "3",
			SafetyCharacteristicHazardCode = "S6U",
		};

		var actual = Map.MapObject<MSS_MaterialSafetyDataSheetSectionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Th", "S6U", false)]
	[InlineData("", "S6U", true)]
	[InlineData("Th", "", true)]
	public void Validation_OnlyOneOfReportSectionNameCode(string reportSectionNameCode, string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new MSS_MaterialSafetyDataSheetSectionInformation();
		subject.ReportSectionNameCode = reportSectionNameCode;
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
