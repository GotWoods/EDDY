using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class SWCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWC*Pf*IsOFxV*I*j5ZFho*Ci";

		var expected = new SWC_SwitchingConditions()
		{
			SwitchingSettlementCode = "Pf",
			StandardPointLocationCode = "IsOFxV",
			AmountCharged = "I",
			StandardPointLocationCode2 = "j5ZFho",
			StandardCarrierAlphaCode = "Ci",
		};

		var actual = Map.MapObject<SWC_SwitchingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pf", true)]
	public void Validation_RequiredSwitchingSettlementCode(string switchingSettlementCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.StandardPointLocationCode = "IsOFxV";
		subject.AmountCharged = "I";
		//Test Parameters
		subject.SwitchingSettlementCode = switchingSettlementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j5ZFho", "Ci", true)]
	[InlineData("j5ZFho", "", false)]
	[InlineData("", "Ci", false)]
	public void Validation_AllAreRequiredSwitchingSettlementCode(string standardPointLocationCode2, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
        //Required fields
        subject.SwitchingSettlementCode = "AB";
        subject.StandardPointLocationCode = "IsOFxV";
		subject.AmountCharged = "I";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IsOFxV", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.SwitchingSettlementCode = "Pf";
		subject.AmountCharged = "I";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.SwitchingSettlementCode = "Pf";
		subject.StandardPointLocationCode = "IsOFxV";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
