using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PT*H*qR*4*R*Vc*n*mx*r*5*lK*ao";

		var expected = new PT_Patron()
		{
			ConditionSegmentLogicalConnector = "H",
			EntityIdentifierCode = "qR",
			Name = "4",
			IdentificationCodeQualifier = "R",
			IdentificationCode = "Vc",
			ChangeTypeCode = "n",
			StandardCarrierAlphaCode = "mx",
			DocketControlNumber = "r",
			DocketIdentification = "5",
			GroupTitle = "lK",
			EntityRelationshipCode = "ao",
		};

		var actual = Map.MapObject<PT_Patron>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("R", "Vc", true)]
	[InlineData("", "Vc", false)]
	[InlineData("R", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "H";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "qR", true)]
	[InlineData("Vc", "", false)]
	public void Validation_ARequiresBIdentificationCode(string identificationCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "H";
		subject.IdentificationCode = identificationCode;
		subject.EntityIdentifierCode = entityIdentifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mx", "qR", false)]
	[InlineData("", "qR", true)]
	[InlineData("mx", "", true)]
	public void Validation_OnlyOneOfStandardCarrierAlphaCode(string standardCarrierAlphaCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "H";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EntityIdentifierCode = entityIdentifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "qR", true)]
	[InlineData("ao", "", false)]
	public void Validation_ARequiresBEntityRelationshipCode(string entityRelationshipCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "H";
		subject.EntityRelationshipCode = entityRelationshipCode;
		subject.EntityIdentifierCode = entityIdentifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
