using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class SLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLA*6*p*f*ah*u*j*7*kq";

		var expected = new SLA_SchoolAccreditationAndLicensing()
		{
			CodeListQualifierCode = "6",
			IndustryCode = "p",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "f",
			DateTimePeriodFormatQualifier = "ah",
			DateTimePeriod = "u",
			CodeListQualifierCode2 = "j",
			IndustryCode2 = "7",
			StateOrProvinceCode = "kq",
		};

		var actual = Map.MapObject<SLA_SchoolAccreditationAndLicensing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		//Required fields
		subject.IndustryCode = "p";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ah";
			subject.DateTimePeriod = "u";
		}
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.IndustryCode2))
		{
			subject.CodeListQualifierCode2 = "j";
			subject.IndustryCode2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		//Required fields
		subject.CodeListQualifierCode = "6";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ah";
			subject.DateTimePeriod = "u";
		}
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.IndustryCode2))
		{
			subject.CodeListQualifierCode2 = "j";
			subject.IndustryCode2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ah", "u", true)]
	[InlineData("ah", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		//Required fields
		subject.CodeListQualifierCode = "6";
		subject.IndustryCode = "p";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.IndustryCode2))
		{
			subject.CodeListQualifierCode2 = "j";
			subject.IndustryCode2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "7", true)]
	[InlineData("j", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		//Required fields
		subject.CodeListQualifierCode = "6";
		subject.IndustryCode = "p";
		//Test Parameters
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ah";
			subject.DateTimePeriod = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kq", "j", false)]
	[InlineData("kq", "", true)]
	[InlineData("", "j", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string codeListQualifierCode2, bool isValidExpected)
	{
		var subject = new SLA_SchoolAccreditationAndLicensing();
		//Required fields
		subject.CodeListQualifierCode = "6";
		subject.IndustryCode = "p";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ah";
			subject.DateTimePeriod = "u";
		}
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.IndustryCode2))
		{
			subject.CodeListQualifierCode2 = "j";
			subject.IndustryCode2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
