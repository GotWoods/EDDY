using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD*E*Jcqi*I*h*p*4*g*DE*Y*m*7R";

		var expected = new CD_ShipmentConditions()
		{
			ConditionSegmentLogicalConnector = "E",
			ConditionCode = "Jcqi",
			ConditionValue = "I",
			ConditionValue2 = "h",
			ConditionValue3 = "p",
			AssignedNumber = 4,
			ChangeTypeCode = "g",
			StandardCarrierAlphaCode = "DE",
			DocketControlNumber = "Y",
			DocketIdentification = "m",
			GroupTitle = "7R",
		};

		var actual = Map.MapObject<CD_ShipmentConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
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
	[InlineData("I", "Jcqi", true)]
	[InlineData("I", "", false)]
	[InlineData("", "Jcqi", true)]
	public void Validation_ARequiresBConditionValue(string conditionValue, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "E";
		//Test Parameters
		subject.ConditionValue = conditionValue;
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "Jcqi", true)]
	[InlineData("h", "", false)]
	[InlineData("", "Jcqi", true)]
	public void Validation_ARequiresBConditionValue2(string conditionValue2, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "E";
		//Test Parameters
		subject.ConditionValue2 = conditionValue2;
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "Jcqi", true)]
	[InlineData("p", "", false)]
	[InlineData("", "Jcqi", true)]
	public void Validation_ARequiresBConditionValue3(string conditionValue3, string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "E";
		//Test Parameters
		subject.ConditionValue3 = conditionValue3;
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
