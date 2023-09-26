using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ERITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ERI*r*bA*5N*3*aw*U3*1V*mt*0e";

		var expected = new ERI_EntityRelationship()
		{
			IdentificationCodeQualifier = "r",
			IdentificationCode = "bA",
			EntityRelationshipCode = "5N",
			IdentificationCodeQualifier2 = "3",
			IdentificationCode2 = "aw",
			EntityRelationshipCode2 = "U3",
			EntityRelationshipCode3 = "1V",
			EntityRelationshipCode4 = "mt",
			HierarchyCode = "0e",
		};

		var actual = Map.MapObject<ERI_EntityRelationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCode = "bA";
		subject.EntityRelationshipCode = "5N";
		subject.EntityRelationshipCode2 = "U3";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "3";
			subject.IdentificationCode2 = "aw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bA", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "r";
		subject.EntityRelationshipCode = "5N";
		subject.EntityRelationshipCode2 = "U3";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "3";
			subject.IdentificationCode2 = "aw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5N", true)]
	public void Validation_RequiredEntityRelationshipCode(string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "r";
		subject.IdentificationCode = "bA";
		subject.EntityRelationshipCode2 = "U3";
		//Test Parameters
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "3";
			subject.IdentificationCode2 = "aw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "aw", true)]
	[InlineData("3", "", false)]
	[InlineData("", "aw", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "r";
		subject.IdentificationCode = "bA";
		subject.EntityRelationshipCode = "5N";
		subject.EntityRelationshipCode2 = "U3";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U3", true)]
	public void Validation_RequiredEntityRelationshipCode2(string entityRelationshipCode2, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "r";
		subject.IdentificationCode = "bA";
		subject.EntityRelationshipCode = "5N";
		//Test Parameters
		subject.EntityRelationshipCode2 = entityRelationshipCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "3";
			subject.IdentificationCode2 = "aw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
