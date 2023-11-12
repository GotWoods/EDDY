using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PT*q*mI*kU*I*7n*5*Gi*3*P*2B*67";

		var expected = new PT_Patron()
		{
			ConditionSegmentLogicalConnector = "q",
			EntityIdentifierCode = "mI",
			Name30CharacterFormat = "kU",
			IdentificationCodeQualifier = "I",
			IdentificationCode = "7n",
			ChangeTypeCode = "5",
			StandardCarrierAlphaCode = "Gi",
			DocketControlNumber = "3",
			DocketIdentification = "P",
			GroupTitle = "2B",
			EntityRelationshipCode = "67",
		};

		var actual = Map.MapObject<PT_Patron>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "I";
			subject.IdentificationCode = "7n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "7n", true)]
	[InlineData("I", "", false)]
	[InlineData("", "7n", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "q";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		if (identificationCode != "")
			subject.EntityIdentifierCode = "mI";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7n", "mI", true)]
	[InlineData("7n", "", false)]
	[InlineData("", "mI", true)]
	public void Validation_ARequiresBIdentificationCode(string identificationCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "q";
		subject.IdentificationCode = identificationCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "I";
			subject.IdentificationCode = "7n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gi", "mI", false)]
	[InlineData("Gi", "", true)]
	[InlineData("", "mI", true)]
	public void Validation_OnlyOneOfStandardCarrierAlphaCode(string standardCarrierAlphaCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "q";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "I";
			subject.IdentificationCode = "7n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("67", "mI", true)]
	[InlineData("67", "", false)]
	[InlineData("", "mI", true)]
	public void Validation_ARequiresBEntityRelationshipCode(string entityRelationshipCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "q";
		subject.EntityRelationshipCode = entityRelationshipCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "I";
			subject.IdentificationCode = "7n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
