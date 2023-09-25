using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class MSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MSS*AV*6*gb*p5*r";

		var expected = new MSS_MaterialSafetyDataSheetSectionInformation()
		{
			ReportSectionNameCode = "AV",
			Description = "6",
			StateOrProvinceCode = "gb",
			CountryCode = "p5",
			ChangeTypeCode = "r",
		};

		var actual = Map.MapObject<MSS_MaterialSafetyDataSheetSectionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("AV", "6", true)]
	[InlineData("AV", "", true)]
	[InlineData("", "6", true)]
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
