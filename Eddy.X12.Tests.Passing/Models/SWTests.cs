using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SW*M*Q*Jp7d*W*vM*mR*9*a*9";

		var expected = new SW_SwitchingCharges()
		{
			TariffApplicationCode = "M",
			ConditionSegmentLogicalConnector = "Q",
			ConditionCode = "Jp7d",
			ConditionValue = "W",
			StandardCarrierAlphaCode = "vM",
			RateValueQualifier = "mR",
			Rate = 9,
			Rule260JunctionCode = "a",
			AssignedNumber = 9,
		};

		var actual = Map.MapObject<SW_SwitchingCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredTariffApplicationCode(string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.ConditionSegmentLogicalConnector = "Q";
		subject.ConditionCode = "Jp7d";
		subject.ConditionValue = "W";
		subject.TariffApplicationCode = tariffApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "M";
		subject.ConditionCode = "Jp7d";
		subject.ConditionValue = "W";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jp7d", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "M";
		subject.ConditionSegmentLogicalConnector = "Q";
		subject.ConditionValue = "W";
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredConditionValue(string conditionValue, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "M";
		subject.ConditionSegmentLogicalConnector = "Q";
		subject.ConditionCode = "Jp7d";
		subject.ConditionValue = conditionValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
