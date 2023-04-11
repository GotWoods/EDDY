using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*c*ze*A7*kh*7*hn*hY*r5Txfl*1eP*evZc1P*94V*gX";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "c",
			CityName = "ze",
			StateOrProvinceCode = "A7",
			CountryCode = "kh",
			FreightStationAccountingCode2 = "7",
			CityName2 = "hn",
			StateOrProvinceCode2 = "hY",
			StandardPointLocationCode = "r5Txfl",
			PostalCode = "1eP",
			StandardPointLocationCode2 = "evZc1P",
			PostalCode2 = "94V",
			CountryCode2 = "gX",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ze", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "A7";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A7", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.CityName = "ze";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("hn", "hY", true)]
	[InlineData("", "hY", false)]
	[InlineData("hn", "", false)]
	public void Validation_AllAreRequiredCityName2(string cityName2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.CityName = "ze";
		subject.StateOrProvinceCode = "A7";
		subject.CityName2 = cityName2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
