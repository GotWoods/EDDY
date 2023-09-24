using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLA*k*D*C*fw*f*j*d*Bm";

		var expected = new SLA_SchoolAccreditationAndLicensing()
		{
			CodeListQualifierCode = "k",
			IndustryCode = "D",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "C",
			DateTimePeriodFormatQualifier = "fw",
			DateTimePeriod = "f",
			CodeListQualifierCode2 = "j",
			IndustryCode2 = "d",
			StateOrProvinceCode = "Bm",
		};

		var actual = Map.MapObject<SLA_SchoolAccreditationAndLicensing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		subject.IndustryCode = "D";
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		subject.CodeListQualifierCode = "k";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("fw", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("fw", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		subject.CodeListQualifierCode = "k";
		subject.IndustryCode = "D";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("j", "d", true)]
	[InlineData("", "d", false)]
	[InlineData("j", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		subject.CodeListQualifierCode = "k";
		subject.IndustryCode = "D";
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bm", "j", false)]
	[InlineData("", "j", true)]
	[InlineData("Bm", "", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string codeListQualifierCode2, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		subject.CodeListQualifierCode = "k";
		subject.IndustryCode = "D";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CodeListQualifierCode2 = codeListQualifierCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
