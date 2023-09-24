using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD*rk*Wgoa*8*4*H*5*x";

		var expected = new CD_ShipmentConditions()
		{
			ConditionSegmentLogicalConnector = "rk",
			ConditionCode = "Wgoa",
			ConditionValue = "8",
			ConditionValue2 = "4",
			ConditionValue3 = "H",
			AssignedNumber = 5,
			ChangeTypeCode = "x",
		};

		var actual = Map.MapObject<CD_ShipmentConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rk", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionCode = "Wgoa";
		//Test Parameters
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wgoa", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new CD_ShipmentConditions();
		//Required fields
		subject.ConditionSegmentLogicalConnector = "rk";
		//Test Parameters
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
