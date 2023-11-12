using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class GSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GS*rk*Dr*dp*HPEoah*jGrN*5*1*B";

		var expected = new GS_FunctionalGroupHeader()
		{
			FunctionalIdentifierCode = "rk",
			ApplicationSendersCode = "Dr",
			ApplicationReceiversCode = "dp",
			Date = "HPEoah",
			Time = "jGrN",
			GroupControlNumber = 5,
			ResponsibleAgencyCode = "1",
			VersionReleaseIndustryIdentifierCode = "B",
		};

		var actual = Map.MapObject<GS_FunctionalGroupHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rk", true)]
	public void Validation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.ApplicationSendersCode = "Dr";
		subject.ApplicationReceiversCode = "dp";
		subject.Date = "HPEoah";
		subject.Time = "jGrN";
		subject.GroupControlNumber = 5;
		subject.ResponsibleAgencyCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = "B";
		subject.FunctionalIdentifierCode = functionalIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dr", true)]
	public void Validation_RequiredApplicationSendersCode(string applicationSendersCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "rk";
		subject.ApplicationReceiversCode = "dp";
		subject.Date = "HPEoah";
		subject.Time = "jGrN";
		subject.GroupControlNumber = 5;
		subject.ResponsibleAgencyCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = "B";
		subject.ApplicationSendersCode = applicationSendersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dp", true)]
	public void Validation_RequiredApplicationReceiversCode(string applicationReceiversCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "rk";
		subject.ApplicationSendersCode = "Dr";
		subject.Date = "HPEoah";
		subject.Time = "jGrN";
		subject.GroupControlNumber = 5;
		subject.ResponsibleAgencyCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = "B";
		subject.ApplicationReceiversCode = applicationReceiversCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HPEoah", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "rk";
		subject.ApplicationSendersCode = "Dr";
		subject.ApplicationReceiversCode = "dp";
		subject.Time = "jGrN";
		subject.GroupControlNumber = 5;
		subject.ResponsibleAgencyCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = "B";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jGrN", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "rk";
		subject.ApplicationSendersCode = "Dr";
		subject.ApplicationReceiversCode = "dp";
		subject.Date = "HPEoah";
		subject.GroupControlNumber = 5;
		subject.ResponsibleAgencyCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = "B";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "rk";
		subject.ApplicationSendersCode = "Dr";
		subject.ApplicationReceiversCode = "dp";
		subject.Date = "HPEoah";
		subject.Time = "jGrN";
		subject.ResponsibleAgencyCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = "B";
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredResponsibleAgencyCode(string responsibleAgencyCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "rk";
		subject.ApplicationSendersCode = "Dr";
		subject.ApplicationReceiversCode = "dp";
		subject.Date = "HPEoah";
		subject.Time = "jGrN";
		subject.GroupControlNumber = 5;
		subject.VersionReleaseIndustryIdentifierCode = "B";
		subject.ResponsibleAgencyCode = responsibleAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "rk";
		subject.ApplicationSendersCode = "Dr";
		subject.ApplicationReceiversCode = "dp";
		subject.Date = "HPEoah";
		subject.Time = "jGrN";
		subject.GroupControlNumber = 5;
		subject.ResponsibleAgencyCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
