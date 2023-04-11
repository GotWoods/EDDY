using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDS*o*c*8x*x*z*X*fo*s*l7*h*RU";

		var expected = new CDS_CaseDescription()
		{
			CaseTypeCode = "o",
			AdministrationOfJusticeOrganizationTypeCode = "c",
			ReferenceIdentificationQualifier = "8x",
			ReferenceIdentification = "x",
			Description = "z",
			IdentificationCodeQualifier = "X",
			IdentificationCode = "fo",
			IdentificationCodeQualifier2 = "s",
			IdentificationCode2 = "l7",
			IdentificationCodeQualifier3 = "h",
			IdentificationCode3 = "RU",
		};

		var actual = Map.MapObject<CDS_CaseDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validatation_RequiredCaseTypeCode(string caseTypeCode, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		subject.AdministrationOfJusticeOrganizationTypeCode = "c";
		subject.CaseTypeCode = caseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validatation_RequiredAdministrationOfJusticeOrganizationTypeCode(string administrationOfJusticeOrganizationTypeCode, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		subject.CaseTypeCode = "o";
		subject.AdministrationOfJusticeOrganizationTypeCode = administrationOfJusticeOrganizationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "x", true)]
	[InlineData("8x", "", false)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		subject.CaseTypeCode = "o";
		subject.AdministrationOfJusticeOrganizationTypeCode = "c";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("X", "fo", true)]
	[InlineData("", "fo", false)]
	[InlineData("X", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		subject.CaseTypeCode = "o";
		subject.AdministrationOfJusticeOrganizationTypeCode = "c";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("s", "l7", true)]
	[InlineData("", "l7", false)]
	[InlineData("s", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		subject.CaseTypeCode = "o";
		subject.AdministrationOfJusticeOrganizationTypeCode = "c";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("h", "RU", true)]
	[InlineData("", "RU", false)]
	[InlineData("h", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		subject.CaseTypeCode = "o";
		subject.AdministrationOfJusticeOrganizationTypeCode = "c";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
