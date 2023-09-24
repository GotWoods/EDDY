using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class GSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GS*nv*xe*Z0*Z1joqo*iAGF*3*j*v";

		var expected = new GS_FunctionalGroupHeader()
		{
			FunctionalIdentifierCode = "nv",
			ApplicationSendersCode = "xe",
			ApplicationReceiversCode = "Z0",
			GroupDate = "Z1joqo",
			GroupTime = "iAGF",
			GroupControlNumber = 3,
			ResponsibleAgencyCode = "j",
			VersionReleaseIndustryIdentifierCode = "v",
		};

		var actual = Map.MapObject<GS_FunctionalGroupHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nv", true)]
	public void Validation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.ApplicationSendersCode = "xe";
		subject.ApplicationReceiversCode = "Z0";
		subject.GroupDate = "Z1joqo";
		subject.GroupTime = "iAGF";
		subject.GroupControlNumber = 3;
		subject.ResponsibleAgencyCode = "j";
		subject.VersionReleaseIndustryIdentifierCode = "v";
		subject.FunctionalIdentifierCode = functionalIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xe", true)]
	public void Validation_RequiredApplicationSendersCode(string applicationSendersCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "nv";
		subject.ApplicationReceiversCode = "Z0";
		subject.GroupDate = "Z1joqo";
		subject.GroupTime = "iAGF";
		subject.GroupControlNumber = 3;
		subject.ResponsibleAgencyCode = "j";
		subject.VersionReleaseIndustryIdentifierCode = "v";
		subject.ApplicationSendersCode = applicationSendersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z0", true)]
	public void Validation_RequiredApplicationReceiversCode(string applicationReceiversCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "nv";
		subject.ApplicationSendersCode = "xe";
		subject.GroupDate = "Z1joqo";
		subject.GroupTime = "iAGF";
		subject.GroupControlNumber = 3;
		subject.ResponsibleAgencyCode = "j";
		subject.VersionReleaseIndustryIdentifierCode = "v";
		subject.ApplicationReceiversCode = applicationReceiversCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z1joqo", true)]
	public void Validation_RequiredGroupDate(string groupDate, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "nv";
		subject.ApplicationSendersCode = "xe";
		subject.ApplicationReceiversCode = "Z0";
		subject.GroupTime = "iAGF";
		subject.GroupControlNumber = 3;
		subject.ResponsibleAgencyCode = "j";
		subject.VersionReleaseIndustryIdentifierCode = "v";
		subject.GroupDate = groupDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iAGF", true)]
	public void Validation_RequiredGroupTime(string groupTime, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "nv";
		subject.ApplicationSendersCode = "xe";
		subject.ApplicationReceiversCode = "Z0";
		subject.GroupDate = "Z1joqo";
		subject.GroupControlNumber = 3;
		subject.ResponsibleAgencyCode = "j";
		subject.VersionReleaseIndustryIdentifierCode = "v";
		subject.GroupTime = groupTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "nv";
		subject.ApplicationSendersCode = "xe";
		subject.ApplicationReceiversCode = "Z0";
		subject.GroupDate = "Z1joqo";
		subject.GroupTime = "iAGF";
		subject.ResponsibleAgencyCode = "j";
		subject.VersionReleaseIndustryIdentifierCode = "v";
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredResponsibleAgencyCode(string responsibleAgencyCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "nv";
		subject.ApplicationSendersCode = "xe";
		subject.ApplicationReceiversCode = "Z0";
		subject.GroupDate = "Z1joqo";
		subject.GroupTime = "iAGF";
		subject.GroupControlNumber = 3;
		subject.VersionReleaseIndustryIdentifierCode = "v";
		subject.ResponsibleAgencyCode = responsibleAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "nv";
		subject.ApplicationSendersCode = "xe";
		subject.ApplicationReceiversCode = "Z0";
		subject.GroupDate = "Z1joqo";
		subject.GroupTime = "iAGF";
		subject.GroupControlNumber = 3;
		subject.ResponsibleAgencyCode = "j";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
