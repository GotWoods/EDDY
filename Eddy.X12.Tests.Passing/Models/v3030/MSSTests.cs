using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class MSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSS*Y7*V*Fw*V4*6";

		var expected = new MSS_MaterialSafetyDataSheetSectionInformation()
		{
			ReportSectionNameCode = "Y7",
			Description = "V",
			StateOrProvinceCode = "Fw",
			CountryCode = "V4",
			ChangeTypeCode = "6",
		};

		var actual = Map.MapObject<MSS_MaterialSafetyDataSheetSectionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Y7", "V", true)]
	[InlineData("Y7", "", true)]
	[InlineData("", "V", true)]
	public void Validation_AtLeastOneReportSectionNameCode(string reportSectionNameCode, string description, bool isValidExpected)
	{
		var subject = new MSS_MaterialSafetyDataSheetSectionInformation();
		//Required fields
		//Test Parameters
		subject.ReportSectionNameCode = reportSectionNameCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
