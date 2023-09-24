using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PT*p*gn*c*A*H1*i*Xc*9*K*R3*TU";

		var expected = new PT_Patron()
		{
			ConditionSegmentLogicalConnector = "p",
			EntityIdentifierCode = "gn",
			Name = "c",
			IdentificationCodeQualifier = "A",
			IdentificationCode = "H1",
			ChangeTypeCode = "i",
			StandardCarrierAlphaCode = "Xc",
			DocketControlNumber = "9",
			DocketIdentification = "K",
			GroupTitle = "R3",
			EntityRelationshipCode = "TU",
		};

		var actual = Map.MapObject<PT_Patron>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "A";
			subject.IdentificationCode = "H1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "H1", true)]
	[InlineData("A", "", false)]
	[InlineData("", "H1", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "p";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		if (identificationCode != "")
			subject.EntityIdentifierCode = "gn";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H1", "gn", true)]
	[InlineData("H1", "", false)]
	[InlineData("", "gn", true)]
	public void Validation_ARequiresBIdentificationCode(string identificationCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "p";
		subject.IdentificationCode = identificationCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "A";
			subject.IdentificationCode = "H1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xc", "gn", false)]
	[InlineData("Xc", "", true)]
	[InlineData("", "gn", true)]
	public void Validation_OnlyOneOfStandardCarrierAlphaCode(string standardCarrierAlphaCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "p";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "A";
			subject.IdentificationCode = "H1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TU", "gn", true)]
	[InlineData("TU", "", false)]
	[InlineData("", "gn", true)]
	public void Validation_ARequiresBEntityRelationshipCode(string entityRelationshipCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "p";
		subject.EntityRelationshipCode = entityRelationshipCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "A";
			subject.IdentificationCode = "H1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
