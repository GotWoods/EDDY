using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RE*p9*av*Az*L1*37*8W*hp*1";

		var expected = new RE_RebillAtInterchange()
		{
			RebillReasonCode = "p9",
			CityName = "av",
			StateOrProvinceCode = "Az",
			StandardCarrierAlphaCode = "L1",
			ShipmentMethodOfPayment = "37",
			CityName2 = "8W",
			StateOrProvinceCode2 = "hp",
			FreightStationAccountingCode = "1",
		};

		var actual = Map.MapObject<RE_RebillAtInterchange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p9", true)]
	public void Validation_RequiredRebillReasonCode(string rebillReasonCode, bool isValidExpected)
	{
		var subject = new RE_RebillAtInterchange();
		subject.CityName = "av";
		subject.RebillReasonCode = rebillReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("av", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new RE_RebillAtInterchange();
		subject.RebillReasonCode = "p9";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
