using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*xE*7*sEHW3JAkQtwnopfW*kZaL*XK";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassification = "xE",
			HazardousClassQualifier = "7",
			HazardousPlacardNotation = "sEHW3JAkQtwnopfW",
			HazardousEndorsement = "kZaL",
			ReportableQuantityCode = "XK",
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xE", true)]
	public void Validation_RequiredHazardousClassification(string hazardousClassification, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.HazardousClassification = hazardousClassification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
