using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class SWCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWC*Ol*yP2rCo*F*ba2ZIG*vx";

		var expected = new SWC_SwitchingConditions()
		{
			SwitchingSettlementCode = "Ol",
			StandardPointLocationCode = "yP2rCo",
			AmountCharged = "F",
			StandardPointLocationCode2 = "ba2ZIG",
			StandardCarrierAlphaCode = "vx",
		};

		var actual = Map.MapObject<SWC_SwitchingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ol", true)]
	public void Validation_RequiredSwitchingSettlementCode(string switchingSettlementCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.StandardPointLocationCode = "yP2rCo";
		//Test Parameters
		subject.SwitchingSettlementCode = switchingSettlementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardPointLocationCode2) || !string.IsNullOrEmpty(subject.StandardPointLocationCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode))
		{
			subject.StandardPointLocationCode2 = "ba2ZIG";
			subject.StandardCarrierAlphaCode = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yP2rCo", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.SwitchingSettlementCode = "Ol";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardPointLocationCode2) || !string.IsNullOrEmpty(subject.StandardPointLocationCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode))
		{
			subject.StandardPointLocationCode2 = "ba2ZIG";
			subject.StandardCarrierAlphaCode = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ba2ZIG", "vx", true)]
	[InlineData("ba2ZIG", "", false)]
	[InlineData("", "vx", false)]
	public void Validation_AllAreRequiredStandardPointLocationCode2(string standardPointLocationCode2, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.SwitchingSettlementCode = "Ol";
		subject.StandardPointLocationCode = "yP2rCo";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
