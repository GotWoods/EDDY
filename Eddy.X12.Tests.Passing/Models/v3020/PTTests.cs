using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PT*gg*DN*iG*cv*2*i";

		var expected = new PT_Patron()
		{
			ConditionSegmentLogicalConnector = "gg",
			EntityIdentifierCode = "DN",
			Name30CharacterFormat = "iG",
			StandardCarrierAlphaCode = "cv",
			ReferenceNumber = "2",
			ChangeTypeCode = "i",
		};

		var actual = Map.MapObject<PT_Patron>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gg", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
