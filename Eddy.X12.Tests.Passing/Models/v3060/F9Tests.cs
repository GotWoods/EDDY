using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class F9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F9*1*PW*Gb*wY*7*PF*uZ*ONMllm*oJG";

		var expected = new F9_OriginStation()
		{
			FreightStationAccountingCode = "1",
			CityName = "PW",
			StateOrProvinceCode = "Gb",
			CountryCode = "wY",
			FreightStationAccountingCode2 = "7",
			CityName2 = "PF",
			StateOrProvinceCode2 = "uZ",
			StandardPointLocationCode = "ONMllm",
			PostalCode = "oJG",
		};

		var actual = Map.MapObject<F9_OriginStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PW", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.StateOrProvinceCode = "Gb";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gb", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.CityName = "PW";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
