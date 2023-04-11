using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BL*xn*o*W*CyIelV*1F*ib*aU*MYbmF7*7y*Bt*FN*JA*dS*6S*ii*ey*D9";

		var expected = new BL_BillingInformation()
		{
			RebillReasonCode = "xn",
			FreightStationAccountingCode = "o",
			FreightStationAccountingCode2 = "W",
			StandardPointLocationCode = "CyIelV",
			CityName = "1F",
			StateOrProvinceCode = "ib",
			CountryCode = "aU",
			StandardPointLocationCode2 = "MYbmF7",
			CityName2 = "7y",
			StateOrProvinceCode2 = "Bt",
			CountryCode2 = "FN",
			StandardCarrierAlphaCode = "JA",
			StandardCarrierAlphaCode2 = "dS",
			StandardCarrierAlphaCode3 = "6S",
			StandardCarrierAlphaCode4 = "ii",
			StandardCarrierAlphaCode5 = "ey",
			StandardCarrierAlphaCode6 = "D9",
		};

		var actual = Map.MapObject<BL_BillingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("xn", true)]
	public void Validatation_RequiredRebillReasonCode(string rebillReasonCode, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		subject.RebillReasonCode = rebillReasonCode;

		subject.FreightStationAccountingCode = "AA";
		subject.FreightStationAccountingCode2 = "AA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("o","1F", true)]
	[InlineData("", "1F", true)]
	[InlineData("o", "", true)]
	public void Validation_AtLeastOneFreightStationAccountingCode(string freightStationAccountingCode, string cityName, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		subject.RebillReasonCode = "xn";
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		subject.CityName = cityName;

        subject.FreightStationAccountingCode2 = "ABC";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("W","7y", true)]
	[InlineData("", "7y", true)]
	[InlineData("W", "", true)]
	public void Validation_AtLeastOneFreightStationAccountingCode2(string freightStationAccountingCode2, string cityName2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		subject.RebillReasonCode = "xn";
		subject.FreightStationAccountingCode2 = freightStationAccountingCode2;
		subject.CityName2 = cityName2;

        subject.FreightStationAccountingCode = "ABC";
        
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1F", true)]
	[InlineData("ib", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		subject.RebillReasonCode = "xn";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;

		subject.FreightStationAccountingCode = "ABC";
        subject.FreightStationAccountingCode2 = "ABC";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "7y", true)]
	[InlineData("Bt", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode2(string stateOrProvinceCode2, string cityName2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		subject.RebillReasonCode = "xn";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.CityName2 = cityName2;

        subject.FreightStationAccountingCode = "ABC";
        subject.FreightStationAccountingCode2 = "ABC";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
