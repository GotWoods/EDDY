using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BL*QU*Z*2*Ny3hTz*f9*Wm*QR*A92jpJ*2H*O6*rg*eO*2f*Ss*u1*Gr*r6";

		var expected = new BL_BillingInformation()
		{
			RebillReasonCode = "QU",
			FreightStationAccountingCode = "Z",
			FreightStationAccountingCode2 = "2",
			StandardPointLocationCode = "Ny3hTz",
			CityName = "f9",
			StateOrProvinceCode = "Wm",
			CountryCode = "QR",
			StandardPointLocationCode2 = "A92jpJ",
			CityName2 = "2H",
			StateOrProvinceCode2 = "O6",
			CountryCode2 = "rg",
			StandardCarrierAlphaCode = "eO",
			StandardCarrierAlphaCode2 = "2f",
			StandardCarrierAlphaCode3 = "Ss",
			StandardCarrierAlphaCode4 = "u1",
			StandardCarrierAlphaCode5 = "Gr",
			StandardCarrierAlphaCode6 = "r6",
		};

		var actual = Map.MapObject<BL_BillingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QU", true)]
	public void Validation_RequiredRebillReasonCode(string rebillReasonCode, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.FreightStationAccountingCode = "Z";
		subject.FreightStationAccountingCode2 = "2";
		//Test Parameters
		subject.RebillReasonCode = rebillReasonCode;
		//At Least one
		subject.StandardPointLocationCode = "Ny3hTz";
		subject.StandardPointLocationCode2 = "A92jpJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "f9";
			subject.StateOrProvinceCode = "Wm";
		}
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "2H";
			subject.StateOrProvinceCode2 = "O6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "QU";
		subject.FreightStationAccountingCode2 = "2";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//At Least one
		subject.StandardPointLocationCode = "Ny3hTz";
		subject.StandardPointLocationCode2 = "A92jpJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "f9";
			subject.StateOrProvinceCode = "Wm";
		}
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "2H";
			subject.StateOrProvinceCode2 = "O6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredFreightStationAccountingCode2(string freightStationAccountingCode2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "QU";
		subject.FreightStationAccountingCode = "Z";
		//Test Parameters
		subject.FreightStationAccountingCode2 = freightStationAccountingCode2;
		//At Least one
		subject.StandardPointLocationCode = "Ny3hTz";
		subject.StandardPointLocationCode2 = "A92jpJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "f9";
			subject.StateOrProvinceCode = "Wm";
		}
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "2H";
			subject.StateOrProvinceCode2 = "O6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Ny3hTz", "f9", true)]
	[InlineData("Ny3hTz", "", true)]
	[InlineData("", "f9", true)]
	public void Validation_AtLeastOneStandardPointLocationCode(string standardPointLocationCode, string cityName, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "QU";
		subject.FreightStationAccountingCode = "Z";
		subject.FreightStationAccountingCode2 = "2";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		subject.CityName = cityName;
		//At Least one
		subject.StandardPointLocationCode2 = "A92jpJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "f9";
			subject.StateOrProvinceCode = "Wm";
		}
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "2H";
			subject.StateOrProvinceCode2 = "O6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f9", "Wm", true)]
	[InlineData("f9", "", false)]
	[InlineData("", "Wm", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "QU";
		subject.FreightStationAccountingCode = "Z";
		subject.FreightStationAccountingCode2 = "2";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.StandardPointLocationCode = "Ny3hTz";
		subject.StandardPointLocationCode2 = "A92jpJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "2H";
			subject.StateOrProvinceCode2 = "O6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("A92jpJ", "2H", true)]
	[InlineData("A92jpJ", "", true)]
	[InlineData("", "2H", true)]
	public void Validation_AtLeastOneStandardPointLocationCode2(string standardPointLocationCode2, string cityName2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "QU";
		subject.FreightStationAccountingCode = "Z";
		subject.FreightStationAccountingCode2 = "2";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.CityName2 = cityName2;
		//At Least one
		subject.StandardPointLocationCode = "Ny3hTz";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "f9";
			subject.StateOrProvinceCode = "Wm";
		}
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "2H";
			subject.StateOrProvinceCode2 = "O6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2H", "O6", true)]
	[InlineData("2H", "", false)]
	[InlineData("", "O6", false)]
	public void Validation_AllAreRequiredCityName2(string cityName2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "QU";
		subject.FreightStationAccountingCode = "Z";
		subject.FreightStationAccountingCode2 = "2";
		//Test Parameters
		subject.CityName2 = cityName2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		//At Least one
		subject.StandardPointLocationCode = "Ny3hTz";
		subject.StandardPointLocationCode2 = "A92jpJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "f9";
			subject.StateOrProvinceCode = "Wm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
