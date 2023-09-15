using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class GSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GS*Ke*bs*Sz*lsFbMH*2OOI*6*v*H";

		var expected = new GS_FunctionalGroupHeader()
		{
			FunctionalIdentifierCode = "Ke",
			ApplicationSendersCode = "bs",
			ApplicationReceiversCode = "Sz",
			Date = "lsFbMH",
			Time = "2OOI",
			GroupControlNumber = 6,
			ResponsibleAgencyCode = "v",
			VersionReleaseIndustryIdentifierCode = "H",
		};

		var actual = Map.MapObject<GS_FunctionalGroupHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ke", true)]
	public void Validation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.ApplicationSendersCode = "bs";
		subject.ApplicationReceiversCode = "Sz";
		subject.Date = "lsFbMH";
		subject.Time = "2OOI";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "v";
		subject.VersionReleaseIndustryIdentifierCode = "H";
		subject.FunctionalIdentifierCode = functionalIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bs", true)]
	public void Validation_RequiredApplicationSendersCode(string applicationSendersCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "Ke";
		subject.ApplicationReceiversCode = "Sz";
		subject.Date = "lsFbMH";
		subject.Time = "2OOI";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "v";
		subject.VersionReleaseIndustryIdentifierCode = "H";
		subject.ApplicationSendersCode = applicationSendersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sz", true)]
	public void Validation_RequiredApplicationReceiversCode(string applicationReceiversCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "Ke";
		subject.ApplicationSendersCode = "bs";
		subject.Date = "lsFbMH";
		subject.Time = "2OOI";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "v";
		subject.VersionReleaseIndustryIdentifierCode = "H";
		subject.ApplicationReceiversCode = applicationReceiversCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lsFbMH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "Ke";
		subject.ApplicationSendersCode = "bs";
		subject.ApplicationReceiversCode = "Sz";
		subject.Time = "2OOI";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "v";
		subject.VersionReleaseIndustryIdentifierCode = "H";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2OOI", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "Ke";
		subject.ApplicationSendersCode = "bs";
		subject.ApplicationReceiversCode = "Sz";
		subject.Date = "lsFbMH";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "v";
		subject.VersionReleaseIndustryIdentifierCode = "H";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "Ke";
		subject.ApplicationSendersCode = "bs";
		subject.ApplicationReceiversCode = "Sz";
		subject.Date = "lsFbMH";
		subject.Time = "2OOI";
		subject.ResponsibleAgencyCode = "v";
		subject.VersionReleaseIndustryIdentifierCode = "H";
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredResponsibleAgencyCode(string responsibleAgencyCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "Ke";
		subject.ApplicationSendersCode = "bs";
		subject.ApplicationReceiversCode = "Sz";
		subject.Date = "lsFbMH";
		subject.Time = "2OOI";
		subject.GroupControlNumber = 6;
		subject.VersionReleaseIndustryIdentifierCode = "H";
		subject.ResponsibleAgencyCode = responsibleAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "Ke";
		subject.ApplicationSendersCode = "bs";
		subject.ApplicationReceiversCode = "Sz";
		subject.Date = "lsFbMH";
		subject.Time = "2OOI";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "v";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
