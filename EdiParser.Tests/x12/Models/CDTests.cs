using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD*K*s0e5*q*A*4*3*Y**L*e*Wd";

		var expected = new CD_ShipmentConditions()
		{
			ConditionSegmentLogicalConnector = "K",
			ConditionCode = "s0e5",
			ConditionValue = "q",
			ConditionValue2 = "A",
			ConditionValue3 = "4",
			AssignedNumber = 3,
			ChangeTypeCode = "Y",
			//StandardCarrierAlphaCode = "BM",
			DocketControlNumber = "L",
			DocketIdentification = "e",
			GroupTitle = "Wd",
		};

		var actual = Map.MapObject<CD_ShipmentConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
	
	Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validatation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		subject.StandardCarrierAlphaCode = "ABCD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("", "BM", true)]
	[InlineData("s0e5", "", true)]
	public void Validation_AtLeastOneConditionCode(string conditionCode, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionSegmentLogicalConnector = "K";
		subject.ConditionCode = conditionCode;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s0e5", "BM", false)]
	[InlineData("", "BM", true)]
	[InlineData("s0e5", "", true)]
	public void Validation_OnlyOneOfConditionCode(string conditionCode, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionSegmentLogicalConnector = "K";
		subject.ConditionCode = conditionCode;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        subject.StandardCarrierAlphaCode = "ABCD";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "s0e5", true)]
	[InlineData("q", "", false)]
	public void Validation_ARequiresBConditionValue(string conditionValue, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionSegmentLogicalConnector = "K";
		subject.ConditionValue = conditionValue;
		subject.ConditionCode = conditionCode;
        subject.StandardCarrierAlphaCode = "ABCD";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "s0e5", true)]
	[InlineData("A", "", false)]
	public void Validation_ARequiresBConditionValue2(string conditionValue2, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionSegmentLogicalConnector = "K";
		subject.ConditionValue2 = conditionValue2;
		subject.ConditionCode = conditionCode;
        subject.StandardCarrierAlphaCode = "ABCD";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "s0e5", true)]
	[InlineData("4", "", false)]
	public void Validation_ARequiresBConditionValue3(string conditionValue3, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionSegmentLogicalConnector = "K";
		subject.ConditionValue3 = conditionValue3;
		subject.ConditionCode = conditionCode;
        subject.StandardCarrierAlphaCode = "ABCD";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
