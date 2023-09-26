using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class SWCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWC*PE*q3iVEp*X*cvoaOZ*Ao";

		var expected = new SWC_SwitchingConditions()
		{
			SwitchingSettlementCode = "PE",
			StandardPointLocationCode = "q3iVEp",
			AmountCharged = "X",
			StandardPointLocationCode2 = "cvoaOZ",
			StandardCarrierAlphaCode = "Ao",
		};

		var actual = Map.MapObject<SWC_SwitchingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PE", true)]
	public void Validation_RequiredSwitchingSettlementCode(string switchingSettlementCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.StandardPointLocationCode = "q3iVEp";
		//Test Parameters
		subject.SwitchingSettlementCode = switchingSettlementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cvoaOZ", "Ao", true)]
	[InlineData("cvoaOZ", "", false)]
	[InlineData("", "Ao", false)]
	public void Validation_AllAreRequiredSwitchingSettlementCode(string standardPointLocationCode2, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
        //Required fields
        subject.SwitchingSettlementCode = "AB";
        subject.StandardPointLocationCode = "q3iVEp";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q3iVEp", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SWC_SwitchingConditions();
		//Required fields
		subject.SwitchingSettlementCode = "PE";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
