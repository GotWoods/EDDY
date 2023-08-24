using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD*k5*H0ub*I*9*r*4*B";

		var expected = new CD_ShipmentConditions()
		{
			ConditionSegmentLogicalConnector = "k5",
			ConditionCode = "H0ub",
			ConditionValue = "I",
			ConditionValue2 = "9",
			ConditionValue3 = "r",
			AssignedNumber = 4,
			Scale = "B",
		};

		var actual = Map.MapObject<CD_ShipmentConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k5", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionCode = "H0ub";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H0ub", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		subject.ConditionSegmentLogicalConnector = "k5";
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
