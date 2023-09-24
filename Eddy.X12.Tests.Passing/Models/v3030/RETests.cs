using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class RETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RE*CS*hi*pO*4e*jE*pA*nF*T";

		var expected = new RE_RebillAtInterchange()
		{
			RebillReasonCode = "CS",
			CityName = "hi",
			StateOrProvinceCode = "pO",
			StandardCarrierAlphaCode = "4e",
			ShipmentMethodOfPayment = "jE",
			CityName2 = "pA",
			StateOrProvinceCode2 = "nF",
			FreightStationAccountingCode = "T",
		};

		var actual = Map.MapObject<RE_RebillAtInterchange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CS", true)]
	public void Validation_RequiredRebillReasonCode(string rebillReasonCode, bool isValidExpected)
	{
		var subject = new RE_RebillAtInterchange();
		subject.CityName = "hi";
		subject.RebillReasonCode = rebillReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hi", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new RE_RebillAtInterchange();
		subject.RebillReasonCode = "CS";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
