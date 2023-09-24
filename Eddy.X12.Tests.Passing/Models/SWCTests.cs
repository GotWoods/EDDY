using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SWCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWC*D2*6n1TFe*n*WtO7JE*T5";

		var expected = new SWC_SwitchingConditions()
		{
			SwitchingSettlementCode = "D2",
			StandardPointLocationCode = "6n1TFe",
			AmountCharged = "n",
			StandardPointLocationCode2 = "WtO7JE",
			StandardCarrierAlphaCode = "T5",
		};

		var actual = Map.MapObject<SWC_SwitchingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D2", true)]
	public void Validation_RequiredSwitchingSettlementCode(string switchingSettlementCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		subject.StandardPointLocationCode = "6n1TFe";
		subject.SwitchingSettlementCode = switchingSettlementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6n1TFe", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		subject.SwitchingSettlementCode = "D2";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("WtO7JE", "T5", true)]
	[InlineData("", "T5", false)]
	[InlineData("WtO7JE", "", false)]
	public void Validation_AllAreRequiredStandardPointLocationCode2(string standardPointLocationCode2, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		subject.SwitchingSettlementCode = "D2";
		subject.StandardPointLocationCode = "6n1TFe";
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
