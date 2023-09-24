using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PT*U*TL*gB*O*P2*r*1O*q*P*xh*fj";

		var expected = new PT_Patron()
		{
			ConditionSegmentLogicalConnector = "U",
			EntityIdentifierCode = "TL",
			Name30CharacterFormat = "gB",
			IdentificationCodeQualifier = "O",
			IdentificationCode = "P2",
			ChangeTypeCode = "r",
			StandardCarrierAlphaCode = "1O",
			DocketControlNumber = "q",
			DocketIdentification = "P",
			GroupTitle = "xh",
			EntityRelationshipCode = "fj",
		};

		var actual = Map.MapObject<PT_Patron>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "O";
			subject.IdentificationCode = "P2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "P2", true)]
	[InlineData("O", "", false)]
	[InlineData("", "P2", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "U";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		if (identificationCode != "")
			subject.EntityIdentifierCode = "TL";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P2", "TL", true)]
	[InlineData("P2", "", false)]
	[InlineData("", "TL", true)]
	public void Validation_ARequiresBIdentificationCode(string identificationCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "U";
		subject.IdentificationCode = identificationCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "O";
			subject.IdentificationCode = "P2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1O", "TL", false)]
	[InlineData("1O", "", true)]
	[InlineData("", "TL", true)]
	public void Validation_OnlyOneOfStandardCarrierAlphaCode(string standardCarrierAlphaCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "U";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "O";
			subject.IdentificationCode = "P2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fj", "TL", true)]
	[InlineData("fj", "", false)]
	[InlineData("", "TL", true)]
	public void Validation_ARequiresBEntityRelationshipCode(string entityRelationshipCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "U";
		subject.EntityRelationshipCode = entityRelationshipCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "O";
			subject.IdentificationCode = "P2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
