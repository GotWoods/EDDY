using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ERITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ERI*G*As*vs*C*hw*Qe*I0*O3*nF";

		var expected = new ERI_EntityRelationship()
		{
			IdentificationCodeQualifier = "G",
			IdentificationCode = "As",
			EntityRelationshipCode = "vs",
			IdentificationCodeQualifier2 = "C",
			IdentificationCode2 = "hw",
			EntityRelationshipCode2 = "Qe",
			EntityRelationshipCode3 = "I0",
			EntityRelationshipCode4 = "O3",
			HierarchyCode = "nF",
		};

		var actual = Map.MapObject<ERI_EntityRelationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCode = "As";
		subject.EntityRelationshipCode = "vs";
		subject.EntityRelationshipCode2 = "Qe";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "C";
			subject.IdentificationCode2 = "hw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("As", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "G";
		subject.EntityRelationshipCode = "vs";
		subject.EntityRelationshipCode2 = "Qe";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "C";
			subject.IdentificationCode2 = "hw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vs", true)]
	public void Validation_RequiredEntityRelationshipCode(string entityRelationshipCode, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "G";
		subject.IdentificationCode = "As";
		subject.EntityRelationshipCode2 = "Qe";
		//Test Parameters
		subject.EntityRelationshipCode = entityRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "C";
			subject.IdentificationCode2 = "hw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "hw", true)]
	[InlineData("C", "", false)]
	[InlineData("", "hw", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "G";
		subject.IdentificationCode = "As";
		subject.EntityRelationshipCode = "vs";
		subject.EntityRelationshipCode2 = "Qe";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qe", true)]
	public void Validation_RequiredEntityRelationshipCode2(string entityRelationshipCode2, bool isValidExpected)
	{
		var subject = new ERI_EntityRelationship();
		//Required fields
		subject.IdentificationCodeQualifier = "G";
		subject.IdentificationCode = "As";
		subject.EntityRelationshipCode = "vs";
		//Test Parameters
		subject.EntityRelationshipCode2 = entityRelationshipCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "C";
			subject.IdentificationCode2 = "hw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
