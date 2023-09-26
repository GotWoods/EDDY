using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class ERITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ERI*C*8V*2C*T*uU*Pc*8Q*1C*JF";

		var expected = new ERI_EntityRelationship()
		{
			IdentificationCodeQualifier = "C",
			IdentificationCode = "8V",
			EntityRelationshipCode = "2C",
			IdentificationCodeQualifier2 = "T",
			IdentificationCode2 = "uU",
			EntityRelationshipCode2 = "Pc",
			EntityRelationshipCode3 = "8Q",
			EntityRelationshipCode4 = "1C",
			HierarchyCode = "JF",
		};

		var actual = Map.MapObject<ERI_EntityRelationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCode = "8V";
		subject.EntityRelationshipCode = "2C";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8V", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "C";
		subject.EntityRelationshipCode = "2C";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2C", true)]
	public void Validation_RequiredEntityRelationshipCode(string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "C";
		subject.IdentificationCode = "8V";
		//Test Parameters
		subject.EntityRelationshipCode = entityRelationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
