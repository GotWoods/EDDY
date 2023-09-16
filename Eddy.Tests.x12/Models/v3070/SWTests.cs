using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SW*B*6*5tbA*T*KD*cu*7*0*5";

		var expected = new SW_SwitchingCharges()
		{
			TariffApplicationCode = "B",
			ConditionSegmentLogicalConnector = "6",
			ConditionCode = "5tbA",
			ConditionValue = "T",
			StandardCarrierAlphaCode = "KD",
			RateValueQualifier = "cu",
			Rate = 7,
			Rule260JunctionCode = "0",
			AssignedNumber = 5,
		};

		var actual = Map.MapObject<SW_SwitchingCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredTariffApplicationCode(string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.ConditionSegmentLogicalConnector = "6";
		subject.ConditionCode = "5tbA";
		subject.ConditionValue = "T";
		subject.TariffApplicationCode = tariffApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "B";
		subject.ConditionCode = "5tbA";
		subject.ConditionValue = "T";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5tbA", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "B";
		subject.ConditionSegmentLogicalConnector = "6";
		subject.ConditionValue = "T";
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredConditionValue(string conditionValue, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "B";
		subject.ConditionSegmentLogicalConnector = "6";
		subject.ConditionCode = "5tbA";
		subject.ConditionValue = conditionValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
