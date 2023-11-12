using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class GSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GS*zg*P9*5f*tvQEuCv1*8pRr*6*m*d";

		var expected = new GS_FunctionalGroupHeader()
		{
			FunctionalIdentifierCode = "zg",
			ApplicationSendersCode = "P9",
			ApplicationReceiversCode = "5f",
			Date = "tvQEuCv1",
			Time = "8pRr",
			GroupControlNumber = 6,
			ResponsibleAgencyCode = "m",
			VersionReleaseIndustryIdentifierCode = "d",
		};

		var actual = Map.MapObject<GS_FunctionalGroupHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zg", true)]
	public void Validation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.ApplicationSendersCode = "P9";
		subject.ApplicationReceiversCode = "5f";
		subject.Date = "tvQEuCv1";
		subject.Time = "8pRr";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "m";
		subject.VersionReleaseIndustryIdentifierCode = "d";
		subject.FunctionalIdentifierCode = functionalIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P9", true)]
	public void Validation_RequiredApplicationSendersCode(string applicationSendersCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "zg";
		subject.ApplicationReceiversCode = "5f";
		subject.Date = "tvQEuCv1";
		subject.Time = "8pRr";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "m";
		subject.VersionReleaseIndustryIdentifierCode = "d";
		subject.ApplicationSendersCode = applicationSendersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5f", true)]
	public void Validation_RequiredApplicationReceiversCode(string applicationReceiversCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "zg";
		subject.ApplicationSendersCode = "P9";
		subject.Date = "tvQEuCv1";
		subject.Time = "8pRr";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "m";
		subject.VersionReleaseIndustryIdentifierCode = "d";
		subject.ApplicationReceiversCode = applicationReceiversCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tvQEuCv1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "zg";
		subject.ApplicationSendersCode = "P9";
		subject.ApplicationReceiversCode = "5f";
		subject.Time = "8pRr";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "m";
		subject.VersionReleaseIndustryIdentifierCode = "d";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8pRr", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "zg";
		subject.ApplicationSendersCode = "P9";
		subject.ApplicationReceiversCode = "5f";
		subject.Date = "tvQEuCv1";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "m";
		subject.VersionReleaseIndustryIdentifierCode = "d";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "zg";
		subject.ApplicationSendersCode = "P9";
		subject.ApplicationReceiversCode = "5f";
		subject.Date = "tvQEuCv1";
		subject.Time = "8pRr";
		subject.ResponsibleAgencyCode = "m";
		subject.VersionReleaseIndustryIdentifierCode = "d";
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredResponsibleAgencyCode(string responsibleAgencyCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "zg";
		subject.ApplicationSendersCode = "P9";
		subject.ApplicationReceiversCode = "5f";
		subject.Date = "tvQEuCv1";
		subject.Time = "8pRr";
		subject.GroupControlNumber = 6;
		subject.VersionReleaseIndustryIdentifierCode = "d";
		subject.ResponsibleAgencyCode = responsibleAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new GS_FunctionalGroupHeader();
		subject.FunctionalIdentifierCode = "zg";
		subject.ApplicationSendersCode = "P9";
		subject.ApplicationReceiversCode = "5f";
		subject.Date = "tvQEuCv1";
		subject.Time = "8pRr";
		subject.GroupControlNumber = 6;
		subject.ResponsibleAgencyCode = "m";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
