using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*pE*N*U*j*b*a*b*B*2T*Do*EG*m";

		var expected = new NM1_IndividualOrOrganizationalName()
		{
			EntityIdentifierCode = "pE",
			EntityTypeQualifier = "N",
			NameLastOrOrganizationName = "U",
			NameFirst = "j",
			NameMiddle = "b",
			NamePrefix = "a",
			NameSuffix = "b",
			IdentificationCodeQualifier = "B",
			IdentificationCode = "2T",
			EntityRelationshipCode = "Do",
			EntityIdentifierCode2 = "EG",
			NameLastOrOrganizationName2 = "m",
		};

		var actual = Map.MapObject<NM1_IndividualOrOrganizationalName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pE", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityTypeQualifier = "N";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "B";
			subject.IdentificationCode = "2T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "pE";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "B";
			subject.IdentificationCode = "2T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "2T", true)]
	[InlineData("B", "", false)]
	[InlineData("", "2T", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "pE";
		subject.EntityTypeQualifier = "N";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("EG", "Do", true)]
	[InlineData("EG", "", false)]
	[InlineData("", "Do", true)]
	public void Validation_ARequiresBEntityIdentifierCode2(string entityIdentifierCode2, string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "pE";
		subject.EntityTypeQualifier = "N";
		//Test Parameters
		subject.EntityIdentifierCode2 = entityIdentifierCode2;
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "B";
			subject.IdentificationCode = "2T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "U", true)]
	[InlineData("m", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBNameLastOrOrganizationName2(string nameLastOrOrganizationName2, string nameLastOrOrganizationName, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "pE";
		subject.EntityTypeQualifier = "N";
		//Test Parameters
		subject.NameLastOrOrganizationName2 = nameLastOrOrganizationName2;
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "B";
			subject.IdentificationCode = "2T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
