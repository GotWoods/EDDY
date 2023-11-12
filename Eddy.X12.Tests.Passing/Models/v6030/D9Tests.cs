using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*U*ZI*qd*HP*v*B1*1y*lDnGDg*CYY*9vPRCh*Ezh*uL";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "U",
			CityName = "ZI",
			StateOrProvinceCode = "qd",
			CountryCode = "HP",
			FreightStationAccountingCode2 = "v",
			CityName2 = "B1",
			StateOrProvinceCode2 = "1y",
			StandardPointLocationCode = "lDnGDg",
			PostalCode = "CYY",
			StandardPointLocationCode2 = "9vPRCh",
			PostalCode2 = "Ezh",
			CountryCode2 = "uL",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZI", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "qd";
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "B1";
			subject.StateOrProvinceCode2 = "1y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qd", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.CityName = "ZI";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "B1";
			subject.StateOrProvinceCode2 = "1y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B1", "1y", true)]
	[InlineData("B1", "", false)]
	[InlineData("", "1y", false)]
	public void Validation_AllAreRequiredCityName2(string cityName2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.CityName = "ZI";
		subject.StateOrProvinceCode = "qd";
		subject.CityName2 = cityName2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
