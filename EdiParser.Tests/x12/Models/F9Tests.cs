using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class F9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F9*m*Sx*2R*cQ*R*VD*JM*if3rWN*WZG*nZZjEh*eez*3S";

		var expected = new F9_OriginStation()
		{
			FreightStationAccountingCode = "m",
			CityName = "Sx",
			StateOrProvinceCode = "2R",
			CountryCode = "cQ",
			FreightStationAccountingCode2 = "R",
			CityName2 = "VD",
			StateOrProvinceCode2 = "JM",
			StandardPointLocationCode = "if3rWN",
			PostalCode = "WZG",
			StandardPointLocationCode2 = "nZZjEh",
			PostalCode2 = "eez",
			CountryCode2 = "3S",
		};

		var actual = Map.MapObject<F9_OriginStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sx", true)]
	public void Validatation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.StateOrProvinceCode = "2R";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2R", true)]
	public void Validatation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.CityName = "Sx";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("VD", "JM", true)]
	[InlineData("", "JM", false)]
	[InlineData("VD", "", false)]
	public void Validation_AllAreRequiredCityName2(string cityName2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.CityName = "Sx";
		subject.StateOrProvinceCode = "2R";
		subject.CityName2 = cityName2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
