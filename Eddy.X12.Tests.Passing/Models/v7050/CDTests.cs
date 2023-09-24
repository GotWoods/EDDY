using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class CDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD*I*qWKM*y*s*D*6*N*Cc*x*3*32";

		var expected = new CD_ShipmentConditions()
		{
			ConditionSegmentLogicalConnector = "I",
			ConditionCode = "qWKM",
			ConditionValue = "y",
			ConditionValue2 = "s",
			ConditionValue3 = "D",
			AssignedNumber = 6,
			ChangeTypeCode = "N",
			StandardCarrierAlphaCode = "Cc",
			DocketControlNumber = "x",
			DocketIdentification = "3",
			GroupTitle = "32",
		};

		var actual = Map.MapObject<CD_ShipmentConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		//Test Parameters
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		//At Least one
		subject.ConditionCode = "qWKM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "qWKM", true)]
	[InlineData("y", "", false)]
	[InlineData("", "qWKM", true)]
	public void Validation_ARequiresBConditionValue(string conditionValue, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "I";
		//Test Parameters
		subject.ConditionValue = conditionValue;
		subject.ConditionCode = conditionCode;
        //At Least one
        if (string.IsNullOrEmpty(subject.ConditionCode))
            subject.StandardCarrierAlphaCode = "Cc";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "qWKM", true)]
	[InlineData("s", "", false)]
	[InlineData("", "qWKM", true)]
	public void Validation_ARequiresBConditionValue2(string conditionValue2, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "I";
		//Test Parameters
		subject.ConditionValue2 = conditionValue2;
		subject.ConditionCode = conditionCode;
        //At Least one
        if (string.IsNullOrEmpty(subject.ConditionCode))
            subject.StandardCarrierAlphaCode = "Cc";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "qWKM", true)]
	[InlineData("D", "", false)]
	[InlineData("", "qWKM", true)]
	public void Validation_ARequiresBConditionValue3(string conditionValue3, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "I";
		//Test Parameters
		subject.ConditionValue3 = conditionValue3;
		subject.ConditionCode = conditionCode;
        //At Least one
        if (string.IsNullOrEmpty(subject.ConditionCode))
            subject.StandardCarrierAlphaCode = "Cc";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
