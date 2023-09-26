using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDS*I*2*bp*L*0*L*lt*6*0e*1*N6";

		var expected = new CDS_CaseDescription()
		{
			CaseTypeCode = "I",
			AdministrationOfJusticeOrganizationTypeCode = "2",
			ReferenceIdentificationQualifier = "bp",
			ReferenceIdentification = "L",
			Description = "0",
			IdentificationCodeQualifier = "L",
			IdentificationCode = "lt",
			IdentificationCodeQualifier2 = "6",
			IdentificationCode2 = "0e",
			IdentificationCodeQualifier3 = "1",
			IdentificationCode3 = "N6",
		};

		var actual = Map.MapObject<CDS_CaseDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredCaseTypeCode(string caseTypeCode, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		//Required fields
		subject.AdministrationOfJusticeOrganizationTypeCode = "2";
		//Test Parameters
		subject.CaseTypeCode = caseTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "L";
			subject.IdentificationCode = "lt";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "6";
			subject.IdentificationCode2 = "0e";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "1";
			subject.IdentificationCode3 = "N6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredAdministrationOfJusticeOrganizationTypeCode(string administrationOfJusticeOrganizationTypeCode, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		//Required fields
		subject.CaseTypeCode = "I";
		//Test Parameters
		subject.AdministrationOfJusticeOrganizationTypeCode = administrationOfJusticeOrganizationTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "L";
			subject.IdentificationCode = "lt";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "6";
			subject.IdentificationCode2 = "0e";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "1";
			subject.IdentificationCode3 = "N6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bp", "L", true)]
	[InlineData("bp", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		//Required fields
		subject.CaseTypeCode = "I";
		subject.AdministrationOfJusticeOrganizationTypeCode = "2";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "L";
			subject.IdentificationCode = "lt";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "6";
			subject.IdentificationCode2 = "0e";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "1";
			subject.IdentificationCode3 = "N6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "lt", true)]
	[InlineData("L", "", false)]
	[InlineData("", "lt", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		//Required fields
		subject.CaseTypeCode = "I";
		subject.AdministrationOfJusticeOrganizationTypeCode = "2";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "6";
			subject.IdentificationCode2 = "0e";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "1";
			subject.IdentificationCode3 = "N6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "0e", true)]
	[InlineData("6", "", false)]
	[InlineData("", "0e", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		//Required fields
		subject.CaseTypeCode = "I";
		subject.AdministrationOfJusticeOrganizationTypeCode = "2";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "L";
			subject.IdentificationCode = "lt";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "1";
			subject.IdentificationCode3 = "N6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "N6", true)]
	[InlineData("1", "", false)]
	[InlineData("", "N6", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new CDS_CaseDescription();
		//Required fields
		subject.CaseTypeCode = "I";
		subject.AdministrationOfJusticeOrganizationTypeCode = "2";
		//Test Parameters
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "L";
			subject.IdentificationCode = "lt";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "6";
			subject.IdentificationCode2 = "0e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
