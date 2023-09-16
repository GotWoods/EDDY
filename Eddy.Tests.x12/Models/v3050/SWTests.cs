using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SW*o*lK*Kpt7*F*SQ*Q8*1*a*8";

		var expected = new SW_SwitchingCharges()
		{
			TariffApplicationCode = "o",
			ConditionSegmentLogicalConnector = "lK",
			ConditionCode = "Kpt7",
			ConditionValue = "F",
			StandardCarrierAlphaCode = "SQ",
			RateValueQualifier = "Q8",
			Rate = 1,
			Rule260JunctionCode = "a",
			AssignedNumber = 8,
		};

		var actual = Map.MapObject<SW_SwitchingCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredTariffApplicationCode(string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.ConditionSegmentLogicalConnector = "lK";
		subject.ConditionCode = "Kpt7";
		subject.ConditionValue = "F";
		subject.TariffApplicationCode = tariffApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lK", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "o";
		subject.ConditionCode = "Kpt7";
		subject.ConditionValue = "F";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kpt7", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "o";
		subject.ConditionSegmentLogicalConnector = "lK";
		subject.ConditionValue = "F";
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredConditionValue(string conditionValue, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "o";
		subject.ConditionSegmentLogicalConnector = "lK";
		subject.ConditionCode = "Kpt7";
		subject.ConditionValue = conditionValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
