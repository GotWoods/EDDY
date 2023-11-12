using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD*K*Ur7b*b*B*e*2*r*ct*e*A*5r";

		var expected = new CD_ShipmentConditions()
		{
			ConditionSegmentLogicalConnector = "K",
			ConditionCode = "Ur7b",
			ConditionValue = "b",
			ConditionValue2 = "B",
			ConditionValue3 = "e",
			AssignedNumber = 2,
			ChangeTypeCode = "r",
			StandardCarrierAlphaCode = "ct",
			DocketControlNumber = "e",
			DocketIdentification = "A",
			GroupTitle = "5r",
		};

		var actual = Map.MapObject<CD_ShipmentConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		//Test Parameters
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ur7b", "ct", false)]
	[InlineData("Ur7b", "", true)]
	[InlineData("", "ct", true)]
	public void Validation_OnlyOneOfConditionCode(string conditionCode, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "K";
		//Test Parameters
		subject.ConditionCode = conditionCode;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "Ur7b", true)]
	[InlineData("b", "", false)]
	[InlineData("", "Ur7b", true)]
	public void Validation_ARequiresBConditionValue(string conditionValue, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "K";
		//Test Parameters
		subject.ConditionValue = conditionValue;
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "Ur7b", true)]
	[InlineData("B", "", false)]
	[InlineData("", "Ur7b", true)]
	public void Validation_ARequiresBConditionValue2(string conditionValue2, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "K";
		//Test Parameters
		subject.ConditionValue2 = conditionValue2;
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "Ur7b", true)]
	[InlineData("e", "", false)]
	[InlineData("", "Ur7b", true)]
	public void Validation_ARequiresBConditionValue3(string conditionValue3, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "K";
		//Test Parameters
		subject.ConditionValue3 = conditionValue3;
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
