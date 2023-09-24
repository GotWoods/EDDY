using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PT*z2*O4*8U*yZ*C";

		var expected = new PT_Patron()
		{
			ConditionSegmentLogicalConnector = "z2",
			EntityIdentifierCode = "O4",
			Name30CharacterFormat = "8U",
			StandardCarrierAlphaCode = "yZ",
			ReferenceNumber = "C",
		};

		var actual = Map.MapObject<PT_Patron>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z2", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.EntityIdentifierCode = "O4";
		subject.Name30CharacterFormat = "8U";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O4", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "z2";
		subject.Name30CharacterFormat = "8U";
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8U", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "z2";
		subject.EntityIdentifierCode = "O4";
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
