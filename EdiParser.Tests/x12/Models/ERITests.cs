using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ERITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ERI*G*tL*0I*g*4U*nr*QY*NT*ze";

		var expected = new ERI_EntityRelationship()
		{
			IdentificationCodeQualifier = "G",
			IdentificationCode = "tL",
			EntityRelationshipCode = "0I",
			IdentificationCodeQualifier2 = "g",
			IdentificationCode2 = "4U",
			EntityRelationshipCode2 = "nr",
			EntityRelationshipCode3 = "QY",
			EntityRelationshipCode4 = "NT",
			HierarchyCode = "ze",
		};

		var actual = Map.MapObject<ERI_EntityRelationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		subject.IdentificationCode = "tL";
		subject.EntityRelationshipCode = "0I";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tL", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		subject.IdentificationCodeQualifier = "G";
		subject.EntityRelationshipCode = "0I";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0I", true)]
	public void Validatation_RequiredEntityRelationshipCode(string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		subject.IdentificationCodeQualifier = "G";
		subject.IdentificationCode = "tL";
		subject.EntityRelationshipCode = entityRelationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
