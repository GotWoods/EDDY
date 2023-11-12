using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAT*FX*6*m*u*f*q*t";

		var expected = new CAT_CategoryOfPatientInformationService()
		{
			ReportTypeCode = "FX",
			ReportTransmissionCode = "6",
			VersionIdentifier = "m",
			CodeListQualifierCode = "u",
			IndustryCode = "f",
			IndustryCode2 = "q",
			VersionIdentifier2 = "t",
		};

		var actual = Map.MapObject<CAT_CategoryOfPatientInformationService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "6", true)]
	[InlineData("m", "", false)]
	[InlineData("", "6", true)]
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
			subject.CodeListQualifierCode = "u";
			subject.IndustryCode = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "f", true)]
	[InlineData("u", "", false)]
	[InlineData("", "f", false)]
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
	[InlineData("q", "f", true)]
	[InlineData("q", "", false)]
	[InlineData("", "f", true)]
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
			subject.CodeListQualifierCode = "u";
			subject.IndustryCode = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "u", true)]
	[InlineData("t", "", false)]
	[InlineData("", "u", true)]
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
			subject.CodeListQualifierCode = "u";
			subject.IndustryCode = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
