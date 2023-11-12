using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SWCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWC*uT*8LJAn6*C*I3RvPI*CK";

		var expected = new SWC_SwitchingConditions()
		{
			SwitchingSettlementCode = "uT",
			StandardPointLocationCode = "8LJAn6",
			AmountCharged = "C",
			StandardPointLocationCode2 = "I3RvPI",
			StandardCarrierAlphaCode = "CK",
		};

		var actual = Map.MapObject<SWC_SwitchingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uT", true)]
	public void Validation_RequiredSwitchingSettlementCode(string switchingSettlementCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.StandardPointLocationCode = "8LJAn6";
		subject.AmountCharged = "C";
		//Test Parameters
		subject.SwitchingSettlementCode = switchingSettlementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I3RvPI", "CK", true)]
	[InlineData("I3RvPI", "", false)]
	[InlineData("", "CK", false)]
	public void Validation_AllAreRequiredSwitchingSettlementCode(string standardPointLocationCode2, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
        subject.SwitchingSettlementCode = "AB";
		subject.StandardPointLocationCode = "8LJAn6";
		subject.AmountCharged = "C";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8LJAn6", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.SwitchingSettlementCode = "uT";
		subject.AmountCharged = "C";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.SwitchingSettlementCode = "uT";
		subject.StandardPointLocationCode = "8LJAn6";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
