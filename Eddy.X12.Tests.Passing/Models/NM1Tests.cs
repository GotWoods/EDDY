using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*9o*x*Y*q*K*3*T*T*Gb*Fl*nv*c";

		var expected = new NM1_IndividualOrOrganizationalName()
		{
			EntityIdentifierCode = "9o",
			EntityTypeQualifier = "x",
			NameLastOrOrganizationName = "Y",
			NameFirst = "q",
			NameMiddle = "K",
			NamePrefix = "3",
			NameSuffix = "T",
			IdentificationCodeQualifier = "T",
			IdentificationCode = "Gb",
			EntityRelationshipCode = "Fl",
			EntityIdentifierCode2 = "nv",
			NameLastOrOrganizationName2 = "c",
		};

		var actual = Map.MapObject<NM1_IndividualOrOrganizationalName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9o", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		subject.EntityTypeQualifier = "x";
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		subject.EntityIdentifierCode = "9o";
		subject.EntityTypeQualifier = entityTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("T", "Gb", true)]
	[InlineData("", "Gb", false)]
	[InlineData("T", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		subject.EntityIdentifierCode = "9o";
		subject.EntityTypeQualifier = "x";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Fl", true)]
	[InlineData("nv", "", false)]
	public void Validation_ARequiresBEntityIdentifierCode2(string entityIdentifierCode2, string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		subject.EntityIdentifierCode = "9o";
		subject.EntityTypeQualifier = "x";
		subject.EntityIdentifierCode2 = entityIdentifierCode2;
		subject.EntityRelationshipCode = entityRelationshipCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Y", true)]
	[InlineData("c", "", false)]
	public void Validation_ARequiresBNameLastOrOrganizationName2(string nameLastOrOrganizationName2, string nameLastOrOrganizationName, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		subject.EntityIdentifierCode = "9o";
		subject.EntityTypeQualifier = "x";
		subject.NameLastOrOrganizationName2 = nameLastOrOrganizationName2;
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
