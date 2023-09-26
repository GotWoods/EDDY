using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*3p*p*e*k*q*j*T*t*ov*iN*MJ";

		var expected = new NM1_IndividualOrOrganizationalName()
		{
			EntityIdentifierCode = "3p",
			EntityTypeQualifier = "p",
			NameLastOrOrganizationName = "e",
			NameFirst = "k",
			NameMiddle = "q",
			NamePrefix = "j",
			NameSuffix = "T",
			IdentificationCodeQualifier = "t",
			IdentificationCode = "ov",
			EntityRelationshipCode = "iN",
			EntityIdentifierCode2 = "MJ",
		};

		var actual = Map.MapObject<NM1_IndividualOrOrganizationalName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3p", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityTypeQualifier = "p";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "t";
			subject.IdentificationCode = "ov";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "3p";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "t";
			subject.IdentificationCode = "ov";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "ov", true)]
	[InlineData("t", "", false)]
	[InlineData("", "ov", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "3p";
		subject.EntityTypeQualifier = "p";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MJ", "iN", true)]
	[InlineData("MJ", "", false)]
	[InlineData("", "iN", true)]
	public void Validation_ARequiresBEntityIdentifierCode2(string entityIdentifierCode2, string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "3p";
		subject.EntityTypeQualifier = "p";
		//Test Parameters
		subject.EntityIdentifierCode2 = entityIdentifierCode2;
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "t";
			subject.IdentificationCode = "ov";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
