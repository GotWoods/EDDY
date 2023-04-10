using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAT*uJ*T*G*x*k*F*Y";

		var expected = new CAT_CategoryOfPatientInformationService()
		{
			ReportTypeCode = "uJ",
			ReportTransmissionCode = "T",
			VersionIdentifier = "G",
			CodeListQualifierCode = "x",
			IndustryCode = "k",
			IndustryCode2 = "F",
			VersionIdentifier2 = "Y",
		};

		var actual = Map.MapObject<CAT_CategoryOfPatientInformationService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "T", true)]
	[InlineData("G", "", false)]
	public void Validation_ARequiresBVersionIdentifier(string versionIdentifier, string reportTransmissionCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		subject.VersionIdentifier = versionIdentifier;
		subject.ReportTransmissionCode = reportTransmissionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("x", "k", true)]
	[InlineData("", "k", false)]
	[InlineData("x", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "k", true)]
	[InlineData("F", "", false)]
	public void Validation_ARequiresBIndustryCode2(string industryCode2, string industryCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		subject.IndustryCode2 = industryCode2;
		subject.IndustryCode = industryCode;

		if (industryCode != "")
			subject.CodeListQualifierCode = "CA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "x", true)]
	[InlineData("Y", "", false)]
	public void Validation_ARequiresBVersionIdentifier2(string versionIdentifier2, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		subject.VersionIdentifier2 = versionIdentifier2;
		subject.CodeListQualifierCode = codeListQualifierCode;

        if (codeListQualifierCode != "")
            subject.IndustryCode = "CA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
