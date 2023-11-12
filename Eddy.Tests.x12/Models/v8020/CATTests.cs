using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class CATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAT*1M*T*B*0*q*o*Q";

		var expected = new CAT_CategoryOfPatientInformationService()
		{
			ReportTypeCode = "1M",
			ReportTransmissionCode = "T",
			VersionIdentifier = "B",
			CodeListQualifierCode = "0",
			IndustryCode = "q",
			IndustryCode2 = "o",
			VersionIdentifier2 = "Q",
		};

		var actual = Map.MapObject<CAT_CategoryOfPatientInformationService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "T", true)]
	[InlineData("B", "", false)]
	[InlineData("", "T", true)]
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
			subject.CodeListQualifierCode = "0";
			subject.IndustryCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "q", true)]
	[InlineData("0", "", false)]
	[InlineData("", "q", false)]
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
	[InlineData("o", "q", true)]
	[InlineData("o", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBIndustryCode2(string industryCode2, string industryCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		//Required fields
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "0";
			subject.IndustryCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "0", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "0", true)]
	public void Validation_ARequiresBVersionIdentifier2(string versionIdentifier2, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new CAT_CategoryOfPatientInformationService();
		//Required fields
		//Test Parameters
		subject.VersionIdentifier2 = versionIdentifier2;
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "0";
			subject.IndustryCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
