using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class MSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSS*00*U*Ta*IU*c*M*Pnz";

		var expected = new MSS_MaterialSafetyDataSheetSectionInformation()
		{
			ReportSectionNameCode = "00",
			Description = "U",
			StateOrProvinceCode = "Ta",
			CountryCode = "IU",
			ChangeTypeCode = "c",
			ReportSectionNumber = "M",
			SafetyCharacteristicHazardCode = "Pnz",
		};

		var actual = Map.MapObject<MSS_MaterialSafetyDataSheetSectionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("00", "Pnz", false)]
	[InlineData("00", "", true)]
	[InlineData("", "Pnz", true)]
	public void Validation_OnlyOneOfReportSectionNameCode(string reportSectionNameCode, string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new MSS_MaterialSafetyDataSheetSectionInformation();
		//Required fields
		//Test Parameters
		subject.ReportSectionNameCode = reportSectionNameCode;
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
