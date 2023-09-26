using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*Uu*f*0*N*5*s*N*D*QK*GE*6C*0";

		var expected = new NM1_IndividualOrOrganizationalName()
		{
			EntityIdentifierCode = "Uu",
			EntityTypeQualifier = "f",
			NameLastOrOrganizationName = "0",
			NameFirst = "N",
			NameMiddle = "5",
			NamePrefix = "s",
			NameSuffix = "N",
			IdentificationCodeQualifier = "D",
			IdentificationCode = "QK",
			EntityRelationshipCode = "GE",
			EntityIdentifierCode2 = "6C",
			NameLastOrOrganizationName2 = "0",
		};

		var actual = Map.MapObject<NM1_IndividualOrOrganizationalName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uu", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityTypeQualifier = "f";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "D";
			subject.IdentificationCode = "QK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "Uu";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "D";
			subject.IdentificationCode = "QK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "QK", true)]
	[InlineData("D", "", false)]
	[InlineData("", "QK", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "Uu";
		subject.EntityTypeQualifier = "f";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6C", "GE", true)]
	[InlineData("6C", "", false)]
	[InlineData("", "GE", true)]
	public void Validation_ARequiresBEntityIdentifierCode2(string entityIdentifierCode2, string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "Uu";
		subject.EntityTypeQualifier = "f";
		//Test Parameters
		subject.EntityIdentifierCode2 = entityIdentifierCode2;
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "D";
			subject.IdentificationCode = "QK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "0", true)]
	[InlineData("0", "", false)]
	[InlineData("", "0", true)]
	public void Validation_ARequiresBNameLastOrOrganizationName2(string nameLastOrOrganizationName2, string nameLastOrOrganizationName, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "Uu";
		subject.EntityTypeQualifier = "f";
		//Test Parameters
		subject.NameLastOrOrganizationName2 = nameLastOrOrganizationName2;
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "D";
			subject.IdentificationCode = "QK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
