using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SW*l*xh*MCWi*a*ZT*Pb*1*U*2";

		var expected = new SW_SwitchingCharges()
		{
			TariffApplicationCode = "l",
			ConditionSegmentLogicalConnector = "xh",
			ConditionCode = "MCWi",
			ConditionValue = "a",
			StandardCarrierAlphaCode = "ZT",
			RateValueQualifier = "Pb",
			Rate = 1,
			Rule260JunctionCode = "U",
			AssignedNumber = 2,
		};

		var actual = Map.MapObject<SW_SwitchingCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTariffApplicationCode(string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.ConditionSegmentLogicalConnector = "xh";
		subject.ConditionCode = "MCWi";
		subject.ConditionValue = "a";
		subject.TariffApplicationCode = tariffApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xh", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "l";
		subject.ConditionCode = "MCWi";
		subject.ConditionValue = "a";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MCWi", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "l";
		subject.ConditionSegmentLogicalConnector = "xh";
		subject.ConditionValue = "a";
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredConditionValue(string conditionValue, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "l";
		subject.ConditionSegmentLogicalConnector = "xh";
		subject.ConditionCode = "MCWi";
		subject.ConditionValue = conditionValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
