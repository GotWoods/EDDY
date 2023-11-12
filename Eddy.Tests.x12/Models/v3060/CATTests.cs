using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAT*g2*R*0*s*v*0";

		var expected = new CAT_CategoryOfPatientInformationService()
		{
			ReportTypeCode = "g2",
			ReportTransmissionCode = "R",
			VersionIdentifier = "0",
			CodeListQualifierCode = "s",
			IndustryCode = "v",
			IndustryCode2 = "0",
		};

		var actual = Map.MapObject<CAT_CategoryOfPatientInformationService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "R", true)]
	[InlineData("0", "", false)]
	[InlineData("", "R", true)]
	public void Validation_ARequiresBVersionIdentifier(string versionIdentifier, string reportTransmissionCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		//Required fields
		//Test Parameters
		subject.VersionIdentifier = versionIdentifier;
		subject.ReportTransmissionCode = reportTransmissionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "s";
			subject.IndustryCode = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "v", true)]
	[InlineData("s", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "v", true)]
	[InlineData("0", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBIndustryCode(string industryCode2, string industryCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		//Required fields
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "s";
			subject.IndustryCode = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
