using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class CDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD*l*ZwYK*U*K*A*2*p*Cm*v*G*VD";

		var expected = new CD_ShipmentConditions()
		{
			ConditionSegmentLogicalConnector = "l",
			ConditionCode = "ZwYK",
			ConditionValue = "U",
			ConditionValue2 = "K",
			ConditionValue3 = "A",
			AssignedNumber = 2,
			ChangeTypeCode = "p",
			StandardCarrierAlphaCode = "Cm",
			DocketControlNumber = "v",
			DocketIdentification = "G",
			GroupTitle = "VD",
		};

		var actual = Map.MapObject<CD_ShipmentConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		//Test Parameters
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		//At Least one
		subject.ConditionCode = "ZwYK";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ZwYK", "", true)]
	[InlineData("", "Cm", true)]
	public void Validation_AtLeastOneConditionCode(string conditionCode, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "l";
		//Test Parameters
		subject.ConditionCode = conditionCode;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("ZwYK", "", true)]
	[InlineData("", "Cm", true)]
	public void Validation_OnlyOneOfConditionCode(string conditionCode, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "l";
		//Test Parameters
		subject.ConditionCode = conditionCode;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "ZwYK", true)]
	[InlineData("U", "", false)]
	[InlineData("", "ZwYK", true)]
	public void Validation_ARequiresBConditionValue(string conditionValue, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "l";
		//Test Parameters
		subject.ConditionValue = conditionValue;
		subject.ConditionCode = conditionCode;
		//At Least one
		if (string.IsNullOrEmpty(subject.ConditionCode))
		    subject.StandardCarrierAlphaCode = "Cm";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "ZwYK", true)]
	[InlineData("K", "", false)]
	[InlineData("", "ZwYK", true)]
	public void Validation_ARequiresBConditionValue2(string conditionValue2, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "l";
		//Test Parameters
		subject.ConditionValue2 = conditionValue2;
		subject.ConditionCode = conditionCode;
        //At Least one
        if (string.IsNullOrEmpty(subject.ConditionCode))
            subject.StandardCarrierAlphaCode = "Cm";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "ZwYK", true)]
	[InlineData("A", "", false)]
	[InlineData("", "ZwYK", true)]
	public void Validation_ARequiresBConditionValue3(string conditionValue3, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "l";
		//Test Parameters
		subject.ConditionValue3 = conditionValue3;
		subject.ConditionCode = conditionCode;
        //At Least one
        if (string.IsNullOrEmpty(subject.ConditionCode))
            subject.StandardCarrierAlphaCode = "Cm";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
