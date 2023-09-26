using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSS*ak*l*di*Z2*l*0*yyA";

		var expected = new MSS_MaterialSafetyDataSheetSectionInformation()
		{
			ReportSectionNameCode = "ak",
			Description = "l",
			StateOrProvinceCode = "di",
			CountryCode = "Z2",
			ChangeTypeCode = "l",
			ReportSectionNumber = "0",
			SafetyCharacteristicHazardCode = "yyA",
		};

		var actual = Map.MapObject<MSS_MaterialSafetyDataSheetSectionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ak", "0", false)]
	[InlineData("ak", "", true)]
	[InlineData("", "0", true)]
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
