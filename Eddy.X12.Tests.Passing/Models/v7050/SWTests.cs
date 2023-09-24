using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class SWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SW*S*u*fbXD*m*eW*bX*4*j*9";

		var expected = new SW_SwitchingCharges()
		{
			TariffApplicationCode = "S",
			ConditionSegmentLogicalConnector = "u",
			ConditionCode = "fbXD",
			ConditionValue = "m",
			StandardCarrierAlphaCode = "eW",
			RateValueQualifier = "bX",
			Rate = 4,
			Rule260JunctionCode = "j",
			AssignedNumber = 9,
		};

		var actual = Map.MapObject<SW_SwitchingCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredTariffApplicationCode(string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.ConditionSegmentLogicalConnector = "u";
		subject.ConditionCode = "fbXD";
		subject.ConditionValue = "m";
		subject.TariffApplicationCode = tariffApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "S";
		subject.ConditionCode = "fbXD";
		subject.ConditionValue = "m";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fbXD", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "S";
		subject.ConditionSegmentLogicalConnector = "u";
		subject.ConditionValue = "m";
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredConditionValue(string conditionValue, bool isValidExpected)
	{
		var subject = new SW_SwitchingCharges();
		subject.TariffApplicationCode = "S";
		subject.ConditionSegmentLogicalConnector = "u";
		subject.ConditionCode = "fbXD";
		subject.ConditionValue = conditionValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
