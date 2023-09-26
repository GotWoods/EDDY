using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ERITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ERI*H*Il*Ix*G*04*MC*j8*rf*Pp";

		var expected = new ERI_EntityRelationship()
		{
			IdentificationCodeQualifier = "H",
			IdentificationCode = "Il",
			EntityRelationshipCode = "Ix",
			IdentificationCodeQualifier2 = "G",
			IdentificationCode2 = "04",
			EntityRelationshipCode2 = "MC",
			EntityRelationshipCode3 = "j8",
			EntityRelationshipCode4 = "rf",
			HierarchyCode = "Pp",
		};

		var actual = Map.MapObject<ERI_EntityRelationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCode = "Il";
		subject.EntityRelationshipCode = "Ix";
		subject.EntityRelationshipCode2 = "MC";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "04";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Il", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "H";
		subject.EntityRelationshipCode = "Ix";
		subject.EntityRelationshipCode2 = "MC";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "04";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ix", true)]
	public void Validation_RequiredEntityRelationshipCode(string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "Il";
		subject.EntityRelationshipCode2 = "MC";
		//Test Parameters
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "04";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "04", true)]
	[InlineData("G", "", false)]
	[InlineData("", "04", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "Il";
		subject.EntityRelationshipCode = "Ix";
		subject.EntityRelationshipCode2 = "MC";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MC", true)]
	public void Validation_RequiredEntityRelationshipCode2(string entityRelationshipCode2, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "Il";
		subject.EntityRelationshipCode = "Ix";
		//Test Parameters
		subject.EntityRelationshipCode2 = entityRelationshipCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "04";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
