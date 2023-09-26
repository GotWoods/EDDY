using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*Ql*R*h*X*J*M*e*v*v1*nb*hy";

		var expected = new NM1_IndividualOrOrganizationalName()
		{
			EntityIdentifierCode = "Ql",
			EntityTypeQualifier = "R",
			NameLastOrOrganizationName = "h",
			NameFirst = "X",
			NameMiddle = "J",
			NamePrefix = "M",
			NameSuffix = "e",
			IdentificationCodeQualifier = "v",
			IdentificationCode = "v1",
			EntityRelationshipCode = "nb",
			EntityIdentifierCode2 = "hy",
		};

		var actual = Map.MapObject<NM1_IndividualOrOrganizationalName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ql", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityTypeQualifier = "R";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "v";
			subject.IdentificationCode = "v1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "Ql";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "v";
			subject.IdentificationCode = "v1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "v1", true)]
	[InlineData("v", "", false)]
	[InlineData("", "v1", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "Ql";
		subject.EntityTypeQualifier = "R";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hy", "nb", true)]
	[InlineData("hy", "", false)]
	[InlineData("", "nb", true)]
	public void Validation_ARequiresBEntityIdentifierCode2(string entityIdentifierCode2, string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "Ql";
		subject.EntityTypeQualifier = "R";
		//Test Parameters
		subject.EntityIdentifierCode2 = entityIdentifierCode2;
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "v";
			subject.IdentificationCode = "v1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
