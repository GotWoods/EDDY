using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSS*2w*i*sg*Pw*7*WBy*g19";

		var expected = new MSS_MaterialSafetyDataSheetSectionInformation()
		{
			ReportSectionNameCode = "2w",
			Description = "i",
			StateOrProvinceCode = "sg",
			CountryCode = "Pw",
			ChangeTypeCode = "7",
			ReportSectionNumber = "WBy",
			SafetyCharacteristicHazardCode = "g19",
		};

		var actual = Map.MapObject<MSS_MaterialSafetyDataSheetSectionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2w", "WBy", false)]
	[InlineData("2w", "", true)]
	[InlineData("", "WBy", true)]
	public void Validation_OnlyOneOfReportSectionNameCode(string reportSectionNameCode, string reportSectionNumber, bool isValidExpected)
	{
		var subject = new MSS_MaterialSafetyDataSheetSectionInformation();
		//Required fields
		//Test Parameters
		subject.ReportSectionNameCode = reportSectionNameCode;
		subject.ReportSectionNumber = reportSectionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
