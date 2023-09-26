using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ERITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ERI*e*8U*N4*D*hD*M4";

		var expected = new ERI_EntityRelationship()
		{
			IdentificationCodeQualifier = "e",
			IdentificationCode = "8U",
			EntityRelationshipCode = "N4",
			IdentificationCodeQualifier2 = "D",
			IdentificationCode2 = "hD",
			EntityRelationshipCode2 = "M4",
		};

		var actual = Map.MapObject<ERI_EntityRelationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCode = "8U";
		subject.EntityRelationshipCode = "N4";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "D";
			subject.IdentificationCode2 = "hD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8U", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "e";
		subject.EntityRelationshipCode = "N4";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "D";
			subject.IdentificationCode2 = "hD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N4", true)]
	public void Validation_RequiredEntityRelationshipCode(string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "e";
		subject.IdentificationCode = "8U";
		//Test Parameters
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "D";
			subject.IdentificationCode2 = "hD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "hD", true)]
	[InlineData("D", "", false)]
	[InlineData("", "hD", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "e";
		subject.IdentificationCode = "8U";
		subject.EntityRelationshipCode = "N4";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
